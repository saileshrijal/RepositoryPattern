namespace RepositoryPattern.Repositories.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
    }
}
