using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderFlow_Management.Data;
using OrderFlow_Management.Services;


namespace OrderFlow_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {

        private readonly AppDbContext appDbContext;
        private readonly StatusServices statusServices;

        public StatusController(AppDbContext appDbContext, StatusServices statusServices)
        {
            this.appDbContext = appDbContext;
            this.statusServices = statusServices;
        }
        [HttpPost("/addStatus")]
        public async Task<IActionResult> AddStatus([FromBody] Status status)
        {
            await statusServices.AddStatus(status);
            return Ok(status);
        }

        [HttpDelete("/DeleteStatus/{Sid}")]
        public async Task<IActionResult> DeleteStatus([FromRoute] int Sid)
        {
            await statusServices.DeleteStatus(Sid);
            return Ok();
        }

        [HttpGet("/getAllStatus")]
        public async Task<IActionResult> GetAllStatus()
        {

           var status = await statusServices.GetAllStatus();
            return Ok(status);

        }
    }
}
