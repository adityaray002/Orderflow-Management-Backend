using Microsoft.EntityFrameworkCore;
using OrderFlow_Management.Data;

namespace OrderFlow_Management.Services
{
    public class ProductsServices
    {
        public readonly AppDbContext appDbContext;

        public ProductsServices(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IResult> AddProducts(Products products)
        {
            appDbContext.Products.Add(products);
            await appDbContext.SaveChangesAsync();
            return Results.Ok(products);
        }

        public async Task<IResult> GetAllProducts()
        {

            List<Products> products = await appDbContext.Products.ToListAsync();
            return Results.Ok(products);
        }
    }
}
