namespace Meetup.BLL.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetById(int entityId);

    void Create(T entity);

    void Update(T entity);

    void Delete(T entity);

    Task<List<T>> GetAll();
}