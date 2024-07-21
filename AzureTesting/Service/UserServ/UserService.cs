using AzureTesting.Database;
using AzureTesting.DTO.User;
using AzureTesting.Model;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AzureTesting.Service.UserServ
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext databaseContext;
        private readonly IConfiguration configuration;
        public UserService(DatabaseContext _databaseContext, IConfiguration _configuration)
        {
            databaseContext = _databaseContext;
            configuration = _configuration;
        }

        public IEnumerable<User> GetUsers() => databaseContext.Users;
        public User? Login(UserLoginDTO loginDTO)
        {
            var user = databaseContext.Users.FirstOrDefault(u => u.Name == loginDTO.Login);
            if (user != null && BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.Password)) 
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public void AddUser(UserRegisterDTO user)
        {
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            User newUser = new User(user.Login, hashPassword, user.Email);
            databaseContext.Users.Add(newUser);
            databaseContext.SaveChanges();        
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }


    }
}
