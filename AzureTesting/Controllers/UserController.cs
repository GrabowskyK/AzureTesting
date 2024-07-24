using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Storage.Blobs;
using AzureTesting.DTO.User;
using AzureTesting.Model;
using AzureTesting.Service.UserServ;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

namespace AzureTesting.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ILogger<UserController> logger;
        private readonly BlobContainerClient _blob;
        public UserController(IUserService _userService, ILogger<UserController> _logger, IConfiguration configuration) 
        {
            userService = _userService;
            logger = _logger;
            var connectionString = configuration["AzureBlobStorage:ConnectionString"];
            var containerName = configuration["AzureBlobStorage:ContainerName"];
            _blob = new BlobContainerClient(connectionString, containerName);
        }

        [HttpPost("AddBlobImage")]
        public async Task<string> Upload(IFormFile file)
        {
            var blobClient = _blob.GetBlobClient(Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));

            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, overwrite: true);
            }

            return blobClient.Uri.ToString();
        }

        //test 'bearer token'
        [HttpGet("TestBearerToken")]
        public ActionResult<string> TestTokenJWT()
        {
            var Id = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var Name = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var result = $"Id: {Id} \n Name: {Name}";
            return Ok(result);
        }


        [HttpPost("Register")]
        public ActionResult<UserRegisterDTO> RegisterUser(UserRegisterDTO user)
        {
            try
            {
                userService.AddUser(user);
                return Ok("User has been registered!");
            }
            catch(Exception ex) 
            {
                logger.LogError(ex.ToString());
                return BadRequest("Something went wrong!");
            }
        }

        [HttpPost("Login")]
        public ActionResult<UserLoginDTO> LoginUser(UserLoginDTO user)
        {
            var loggedUser = userService.Login(user);
            if (loggedUser != null)
            {
                var token = userService.CreateToken(loggedUser);
                return Ok(token);
            }
            else
                return BadRequest("Incorrect password or login!");
        }

        [HttpGet("AllUsers")]
        public ActionResult<User> GetUsers() => Ok(userService.GetUsers());
    }
}
