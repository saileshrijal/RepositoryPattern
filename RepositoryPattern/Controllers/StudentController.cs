using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models;
using RepositoryPattern.Repositories.Interface;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _studentRepository.GetAll();
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Student student)
        {
            var model = new Student()
            {
                Name = student.Name,
                Address = student.Address
            };
            await _unitOfWork.Create(model);
            await _unitOfWork.SaveAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var student = await _studentRepository.GetById(id);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Student student)
        {
            try
            {
                var updateStudent = await _studentRepository.GetById(id);
                if (updateStudent != null)
                {
                    updateStudent.Name = student.Name;
                    updateStudent.Address = student.Address;
                    await _unitOfWork.Update(student);
                    await _unitOfWork.SaveAsync();
                }
                
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var student = await _studentRepository.GetById(id);
                if (student != null)
                {
                    await _unitOfWork.Delete(student);
                    await _unitOfWork.SaveAsync();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
