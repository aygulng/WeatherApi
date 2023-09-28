
using WeatherApi.Models;
using WeatherApi.Services;

namespace WeatherApi
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var CorsSettings = "_corsSettings";
            
            builder.Services.AddSingleton<IWeatherService, WeatherService>();
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

            app.UseCors(CorsSettings);

            app.Run();
        }
    }
}