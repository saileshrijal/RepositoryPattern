using RepositoryPattern.Data;
using RepositoryPattern.Models;
using RepositoryPattern.Repositories.Interface;

namespace RepositoryPattern.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
