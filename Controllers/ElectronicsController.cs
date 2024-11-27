using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderFlow_Management.Data;
using Microsoft.EntityFrameworkCore;
using OrderFlow_Management.Services;

namespace OrderFlow_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectronicsController : ControllerBase
    {

        private readonly AppDbContext appDbContext;
        private readonly ElectronicsServices electronicsServices;

        public ElectronicsController(AppDbContext appDbContext,ElectronicsServices electronicsServices)
        {
            this.appDbContext = appDbContext;
            this.electronicsServices = electronicsServices;
        }
        [HttpPost("/addElectronics")]
        public async Task<IActionResult> AddElectronics([FromBody] Electronics electronics)
        {
            await electronicsServices.AddElectronics(electronics);
            return Ok(electronics);
        }

        [HttpDelete("/DeleteElectronics/{Eid}")]
        public async Task<IActionResult> DeleteElectronics([FromRoute] int Eid)
        {
            await electronicsServices.DeleteElectronics(Eid);
            return Ok();
        }

        [HttpGet("/getAllElectronics")]
        public async Task<IActionResult> GetAllElectronics()
        {
            
           var elec = await electronicsServices.GetAllElectronics();
            return Ok(elec);
           
        }
    }
}
