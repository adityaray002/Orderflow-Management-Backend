using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderFlow_Management.Data;
using OrderFlow_Management.Services;

namespace OrderFlow_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        private readonly UserServices userServices;

        public UserController(AppDbContext appDbContext, UserServices userServices)
        {
            this.appDbContext = appDbContext;
            this.userServices = userServices;
        }

        [HttpPost("/addUser")]
        public async Task<IActionResult> AddUser([FromBody] UserInfo user)
        {
            var existingUser = appDbContext.Users.FirstOrDefault(u => u.Name == user.Name);

            if (existingUser != null)
            {
               
                return BadRequest("User with this name already exists.");
            }
            await userServices.AddUser(user);
            //var electronicsId = user.electronics?.FirstOrDefault()?.Id;
            //await userServices.CreateOrder(user.Id, electronicsId.Value, 1);
            return Ok(user);
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
