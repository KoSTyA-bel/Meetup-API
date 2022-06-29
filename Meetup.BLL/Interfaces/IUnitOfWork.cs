public interface IUnitOfWork
{
    Task<int> Save();
}