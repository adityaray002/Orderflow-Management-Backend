using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderFlow_Management.Data;
using OrderFlow_Management.Services;

namespace OrderFlow_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        private readonly ProductsServices productsServices;

        public ProductsController(AppDbContext appDbContext, ProductsServices productsServices)
        {
            this.appDbContext = appDbContext;
            this.productsServices = productsServices;
        }

        [Authorize]
        [HttpGet("/getAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {

            var products = await productsServices.GetAllProducts();
            return Ok(products);

        }
        [HttpPost("/addProducts")]
        public async Task<IActionResult> AddElectronics([FromBody] Products products)
        {
            await productsServices.AddProducts(products);
            return Ok(products);
        }
    }
}
