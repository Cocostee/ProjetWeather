using ProjetWeather.Models;
using System.Threading.Tasks;

namespace ProjetWeather.Services
{
    public interface IWeatherService
    {
        Task<Weather> GetWeatherAsync(string cityName);
    }
}
