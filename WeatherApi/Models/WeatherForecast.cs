namespace WeatherApi.Models
{
    public class WeatherForecast
    {
        public string Name { get; set; }
        public List<Weather?> weather { get; set; }
        public Main? main { get; set; }
        public int visibility { get; set; }
        public Wind? wind { get; set; }
        public Clouds? clouds { get; set; }
        public int id { get; set; }

    }
        public class Weather
        {
            public int Id { get; set; }
            public string Main { get; set; } = null!;
            public string Description { get; set; } = null!;
            public string Icon { get; set; } = null!;
        }

        public class Main
        {
            public double Temp { get; set; }
            public int Pressure { get; set; }
            public int Humidity { get; set; }
            public double Temp_min { get; set; }
            public double Temp_max { get; set; }
        }

        public class Wind
        {
            public double Speed { get; set; }
            public int Deg { get; set; }
        }

        public class Clouds
        {
            public int All { get; set; }
        }


        
    }

