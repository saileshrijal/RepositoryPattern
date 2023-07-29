using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;

namespace RepositoryPattern.Repositories.Interface
{
    public interface IUnitOfWork
    {
        Task Create<T>(T entity) where T:class;
        Task Delete<T>(T entity) where T:class;
        Task Update<T>(T entity) where T:class;
        Task SaveAsync();
    }
}
