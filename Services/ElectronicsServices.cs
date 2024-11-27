using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderFlow_Management.Data;

namespace OrderFlow_Management.Services
{
    public class ElectronicsServices
    {
        public readonly AppDbContext appDbContext;

        public ElectronicsServices(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IResult> AddElectronics(Electronics electronics)
        {
            appDbContext.Electronics.Add(electronics);
            await appDbContext.SaveChangesAsync();
            return Results.Ok(electronics);
        }

        public async Task<IResult> DeleteElectronics( int Eid)
        {
            var electronics = await appDbContext.Electronics.FindAsync(Eid);

            appDbContext.Electronics.Remove(electronics);

            await appDbContext.SaveChangesAsync();

            return Results.Ok(electronics);
        }

        public async Task<IResult> GetAllElectronics()
        {
             
            List<Electronics> electronicsItem = await appDbContext.Electronics.ToListAsync();
            return Results.Ok(electronicsItem);
        }

    }
}
