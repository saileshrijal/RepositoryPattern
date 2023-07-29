using RepositoryPattern.Data;
using RepositoryPattern.Repositories.Interface;

namespace RepositoryPattern.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create<T>(T entity) where T : class
        {
            await _context.AddAsync(entity);
        }

        public Task Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task Update<T>(T entity) where T : class
        {
            _context.Update(entity);
            return Task.CompletedTask;
        }
    }
}
