using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherApi.Models;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        WeatherDbContext db;
        public CityController(WeatherDbContext context)
        {
            db = context;
            if (!db.Cities.Any())
            {
                db.Cities.Add(new City { Name = "Moscow" });
                
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> Get()
        {
            return await db.Cities.ToListAsync();
        }

        // GET api/cities/2
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> Get(int id)
        {
            City city = await db.Cities.FirstOrDefaultAsync(x => x.Id == id);
            if (city == null)
                return NotFound();
            return new ObjectResult(city);
        }

        // POST api/cities
        [HttpPost]
        public async Task<ActionResult<City>> Post(City city)
        {
            if (city == null)
            {
                return BadRequest();
            }

            db.Cities.Add(city);
            await db.SaveChangesAsync();
            return Ok(city);
        }

       
    }
}