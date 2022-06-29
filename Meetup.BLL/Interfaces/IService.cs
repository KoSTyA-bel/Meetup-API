public interface IService<T> where T : class
{
    Task<T> Create(T entity);

    Task Update(T entity);

    Task Delete(T entity);

    Task<List<T>> GetAll();

    Task<T?> GetById(int id);
}