using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using POCApplication.DatabaseContext;
using System.Configuration;

namespace POCApplication
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            //var builder = WebApplication.CreateBuilder(args);
            //// Add services to the container.
            //builder.Services.AddControllers();
            //// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            //// builder.Services.AddDbContext<ApplicationDbContext>().Add(_configuration.GetConnectionString("DefaultConnection")));
            //var app = builder.Build();

            //// Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}
            //app.UseHttpsRedirection();
            //app.UseAuthorization();
            //app.MapControllers();

            //app.Run();


            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            var startup = new Startup(builder.Configuration); // My custom startup class.

            startup.ConfigureServices(builder.Services); // Add services to the container.

            var app = builder.Build();

            startup.Configure(app, app.Environment); // Configure the HTTP request pipeline.

            app.Run();
        }
    }
}