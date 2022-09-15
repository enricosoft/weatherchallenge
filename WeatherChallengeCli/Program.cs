using WeatherChallengeCli.Services;

namespace WeatherChallengeCli
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var settings = Utils.GetSettings();

            var _citiesService = new Cities(settings["AppSettings:MusementBaseApiUrl"]);
            var _weatherService = new Weather(settings["AppSettings:WeatherApiKey"]);

            /* TODO
            var citiesList = _citiesService.Get();
            _weatherService.Get(new Weather.ForecastRequest()
            {
                coords = new Weather.ForecastRequest.Coords() {
                    Latitude = 0,
                    Longitude = 0
                },
                days = 2
            }).GetAwaiter()
              .GetResult();
            */

            Console.ReadKey();
        }
    }
}