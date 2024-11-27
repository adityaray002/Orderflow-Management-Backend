using Microsoft.EntityFrameworkCore;

namespace OrderFlow_Management.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserInfo> Users { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Electronics> Electronics { get; set; }
        public DbSet<Order> Order { get; set; }

         
    }
}
