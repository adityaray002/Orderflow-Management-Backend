using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderFlow_Management.Data;

namespace OrderFlow_Management.Services
{
    public class UserServices
    {
        public readonly AppDbContext appDbContext;

        public UserServices(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IResult> AddUser(UserInfo user)
        {
            appDbContext.Users.Add(user);
            await appDbContext.SaveChangesAsync();
            return Results.Ok(user);
        }

        public async Task<IResult> DeleteUser(int Uid)
        {
            var user = await appDbContext.Users.FindAsync(Uid);

            appDbContext.Users.Remove(user);

            await appDbContext.SaveChangesAsync();

            return Results.Ok(user);
        }

        public async Task<IResult> GetAllUser()
        {

            List<UserInfo> userInfo = await appDbContext.Users.ToListAsync();
            return Results.Ok(userInfo);
        }

     

        public async Task<IResult> GetUserByEmail(string email)
        {
            var user = await appDbContext.Users.FirstOrDefaultAsync(u=>u.Email==email);
            if (user == null)
            {
                return Results.NotFound($"No user found with email: {email}");
            }

            return Results.Ok(user);
        }

    }
}
