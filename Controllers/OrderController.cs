using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderFlow_Management.Data;
using OrderFlow_Management.Services;

namespace OrderFlow_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        private readonly OrderServices orderServices;

        public OrderController(AppDbContext appDbContext,OrderServices orderServices)
        {
            this.appDbContext = appDbContext;   
            this.orderServices = orderServices;  

        }

        [HttpPost("/order")]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            await orderServices.AddOrder(order);
            return Ok(order);
        }

        [HttpGet("/allorder")]
        public async Task<IActionResult> GetAllOrder()
        {
           
            return Ok(await orderServices.GetAllOrder());
        }


        [HttpGet("/order/{id}")]
        public async Task<IActionResult> GetOrderById([FromRoute] int id)
        {

            return Ok(await orderServices.GetOrderById(id));
        }

        [HttpPut("/updateOrder")]
        public async Task<IActionResult> UpdateOrder([FromBody] Order order)
        {

            return Ok(await orderServices.UpdateOrder(order));
        }
    }
}
