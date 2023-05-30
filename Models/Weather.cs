using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWeather.Models
{
    public class Weather 
    {
        public string CityName { get; set; }
        public double Temperature { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public string WeatherDescription { get; set; }
        public string WeatherIcon { get; set; }
    }
}
