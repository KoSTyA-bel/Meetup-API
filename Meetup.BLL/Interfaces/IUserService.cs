namespace Meetup.BLL.Interfaces;

public interface IUserService
{
    bool IsValidUserInformation(string login, string password);
}
