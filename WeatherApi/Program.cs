using Microsoft.EntityFrameworkCore;
using WeatherApi.Models;
using WeatherApi.Services;

namespace WeatherApi
{
    public class Program
    {

        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<WeatherDbContext>(options => options.UseNpgsql(connectionString));

            builder.Services.AddScoped<IWeatherService, WeatherService>();
            builder.Services.AddHttpClient("weather");
            builder.Services.Configure<WeatherSettings>(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();




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