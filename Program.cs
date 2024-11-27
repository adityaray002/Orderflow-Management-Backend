
using Microsoft.EntityFrameworkCore;
using OrderFlow_Management.Data;
using OrderFlow_Management.Services;

namespace OrderFlow_Management
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(options =>
                 options.UseSqlServer(builder.Configuration.GetConnectionString("AppDb"))

            );


            // Add services to the container.
            builder.Services.AddScoped<ElectronicsServices>();
            builder.Services.AddScoped<StatusServices>();
            builder.Services.AddScoped<UserServices>();
            builder.Services.AddScoped<OrderServices>();
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7122/") // Update with your backend's base URL
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
