using Microsoft.Extensions.Configuration;

namespace WeatherChallengeCli
{
    internal class Program
    {
        private readonly string musementBaseApiUrl = "https://sandbox.musement.com/api";
        private readonly string weatherBaseApiUrl = "http://api.weatherapi.com";
        private static string weatherApiKey;
        private static HttpClient httpClient = new HttpClient();

        private static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config.json", false, true)
                .Build();

            weatherApiKey = configuration["AppSettings:WeatherApiKey"];
        }

        /// <summary>
        /// Retrieve cities from TUI Musement api (only first page)
        /// </summary>
        private void GetCities()
        {
            string citiesApiUrl = $"{musementBaseApiUrl}/v3/cities";
        }

        /// <summary>
        /// Retrieve weather forecast for given coords and for N days, starting from today
        /// </summary>
        private void GetWeatherForCity(CityCoords coords, int days = 1)
        {
            if (days <= 0)
            {
                throw new Exception($"{nameof(days)} parameter must be greater than zero");
            }
            if (coords == null)
            {
                throw new Exception($"{nameof(coords)} parameter must be filled");
            }

            string weatherForCityApiUrl = $"{weatherBaseApiUrl}/v1/forecast.json?key={weatherApiKey}&q={coords.Latitude},{coords.Longitude}&days={days}&aqi=no&alerts=no";
        }

        private class CityCoords
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }
    }
}