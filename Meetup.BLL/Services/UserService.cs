using Meetup.BLL.Interfaces;

namespace Meetup.BLL.Services
{
    public class UserService : IUserService
    {
        public bool IsValidUserInformation(string login, string password)
        {
            return "kostya".Equals(login) && "admin".Equals(password);
        }
    }
}
