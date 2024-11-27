using Microsoft.EntityFrameworkCore;
using OrderFlow_Management.Data;

namespace OrderFlow_Management.Services
{
    public class StatusServices
    {

        public readonly AppDbContext appDbContext;

        public StatusServices(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IResult> AddStatus(Status status)
        {
            appDbContext.Status.Add(status);
            await appDbContext.SaveChangesAsync();
            return Results.Ok(status);
        }

        public async Task<IResult> DeleteStatus(int Sid)
        {
            var status = await appDbContext.Status.FindAsync(Sid);

            appDbContext.Status.Remove(status);

            await appDbContext.SaveChangesAsync();

            return Results.Ok(status);
        }

        public async Task<IResult> GetAllStatus()
        {

            List<Status> statusItem = await appDbContext.Status.ToListAsync();
            return Results.Ok(statusItem);
        }
    }
}
