using Microsoft.AspNetCore.Identity;

namespace AzureTesting.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Roles Role { get; set; } = Roles.Admin;
        public string CreatedAt { get; set; } = DateTime.Now.ToString();

        public User(string name, string password, string email)
        {
            Name = name;
            Password = password;
            Email = email;
        }

        public enum Roles
        {
            Admin,
            //... could be more
        }

    }
}
