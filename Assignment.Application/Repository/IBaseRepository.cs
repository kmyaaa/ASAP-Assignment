namespace Assignment.Application.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        T Update(T entity);
        Task Delete(int id);
    }
}
