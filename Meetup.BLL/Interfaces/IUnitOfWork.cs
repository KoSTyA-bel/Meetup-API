namespace Meetup.BLL.Interfaces;

public interface IUnitOfWork
{
    Task<int> Save();
}