using AzureTesting.DTO.User;
using AzureTesting.Model;

namespace AzureTesting.Service.UserServ
{
    public interface IUserService
    {
        string CreateToken(User user);
        void AddUser(UserRegisterDTO user);
        User? Login(UserLoginDTO loginDTO);
        IEnumerable<User> GetUsers();
    }
}