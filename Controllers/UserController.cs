using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrderFlow_Management.Data;
using OrderFlow_Management.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OrderFlow_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        private readonly UserServices userServices;
        private readonly IConfiguration configuration;
        public UserController(AppDbContext appDbContext, UserServices userServices, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.userServices = userServices;
            this.configuration = configuration;
        }

        [HttpPost("/addUser")]
        public async Task<IActionResult> AddUser([FromBody] UserInfo user)
        {
            var existingUser = appDbContext.Users.FirstOrDefault(u => u.Email == user.Email);

            if (existingUser != null)
            {
               
                return BadRequest("User with this Email already exists.");
            }
            else
            {
                await userServices.AddUser(user);
                return Ok(user);
            }
           
            //var electronicsId = user.electronics?.FirstOrDefault()?.Id;
            //await userServices.CreateOrder(user.Id, electronicsId.Value, 1);
           
        }

        [HttpPost("/loginuser")]
        public async Task<IActionResult> LoginUser([FromBody] UserDTO userDto)
        {
            var user = appDbContext.Users.FirstOrDefault(u => u.Email == userDto.email && u.Password == userDto.password);

            if (user != null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim("UserId",user.Id.ToString()),
                    new Claim("Email",user.Email.ToString()),

                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddMinutes(60), signingCredentials: signIn);
                string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new {Token =  tokenValue, User = user});
               // return Ok(user);
            }

            return BadRequest("Incorrect Details");
        }

        [HttpDelete("/DeleteUser/{Uid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int Uid)
        {
            await userServices.DeleteUser(Uid);
            return Ok();
        }

        [HttpGet("/getAllUser")]
        public async Task<IActionResult> GetAllUser()
        {

            var user = await userServices.GetAllUser();
            return Ok(user);

        }

        [HttpGet("/getUserByEmail/{email}")]
        public async Task<IActionResult> GetUserByEmail([FromRoute]string email)
        {

            var user = await userServices.GetUserByEmail(email);
            return Ok(user);

        }
    }
}
