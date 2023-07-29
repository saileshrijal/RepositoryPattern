using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using RepositoryPattern.Repositories.Interface;

namespace RepositoryPattern.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        private DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id)??throw new Exception("Not Found");
        }
    }
}
