namespace AzureTesting.DTO.User
{
    public class UserRegisterDTO
    {
        public string Login { get; set; }   
        public string Password { get; set; }
        public string Email { get; set; }

        public UserRegisterDTO(string login, string password, string email)
        {
            Login = login;
            Password = password;
            Email = email;
        }
    }
}
