using ProjetWeather.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjetWeather.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Weather> GetWeatherAsync(string cityName)
        {
            string apiKey = "3acfe95acdd447cbb3274612233005";
            string requestUrl = $"https://api.weatherapi.com/v1/current.json?key={apiKey}&q={cityName}";
            HttpResponseMessage response;

            try
            {
                response = await _httpClient.GetAsync(requestUrl);
            }
            catch (HttpRequestException e)
            {
                throw new Exception($"Erreur lors de la récupération des données météo : {e.Message}");
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Erreur lors de la récupération des données météo : {response.StatusCode}");
            }

            string content;

            try
            {
                content = await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Erreur lors de la lecture des données météo : {e.Message}");
            }

            dynamic jsonResponse;

            try
            {
                jsonResponse = JsonConvert.DeserializeObject(content);
            }
            catch (JsonException e)
            {
                throw new Exception($"Erreur lors de l'analyse des données météo : {e.Message}");
            }

            if (jsonResponse == null || jsonResponse.current == null || jsonResponse.location == null)
            {
                throw new Exception("Erreur lors de l'analyse des données météo");
            }

            return new Weather
            {
                CityName = jsonResponse.location.name,
                Temperature = jsonResponse.current.temp_c,
                Humidity = jsonResponse.current.humidity,
                WindSpeed = jsonResponse.current.wind_kph,
                WeatherDescription = jsonResponse.current.condition.text,
                WeatherIcon = jsonResponse.current.condition.icon
            };
        }
    }



}