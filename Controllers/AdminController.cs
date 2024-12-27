using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class AdminController : ControllerBase
    {

        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;

        public AdminController(AppDbContext appDbContext,IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
           this.configuration = configuration;
        }

        [HttpPost("/addAdmin")]
        public async Task<IActionResult> AddAdmin([FromBody] Admin admin)
        {
            var existingAdmin = appDbContext.Admin.FirstOrDefault(a => a.Email == admin.Email);

            if (existingAdmin != null)
            {

                return BadRequest("Admin with this Email already exists.");
            }
            appDbContext.Admin.Add(admin);
            await appDbContext.SaveChangesAsync();
            return Ok(admin);
           
        }

        [HttpPost("/loginadmin")]
        public async Task<IActionResult> LoginAdmin([FromBody] AdminDTO adminDTO)
        {
            var admin = appDbContext.Admin.FirstOrDefault(a => a.Email == adminDTO.email && a.Password == adminDTO.password);

            if (admin != null)
            {
                var claims = new[]
               {
                    new Claim(JwtRegisteredClaimNames.Sub,configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim("AdminId",admin.Id.ToString()),
                    new Claim("Email",admin.Email.ToString()),

                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddMinutes(60), signingCredentials: signIn);
                string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { Token = tokenValue, Admin = admin });
               // return Ok(admin);
            }

            return BadRequest("Incorrect Details");
        }
    }
}
