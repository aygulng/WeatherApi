using Microsoft.EntityFrameworkCore;

namespace WeatherApi.Models
{
    public class WeatherDbContext : DbContext
    {

        public DbSet<City> Cities { get; set; }

        public WeatherDbContext(DbContextOptions<WeatherDbContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
