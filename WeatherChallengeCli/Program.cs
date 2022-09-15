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

            var citiesList = _citiesService.Get().GetAwaiter().GetResult();
            if (citiesList != null)
            {
                foreach (var city in citiesList.Cities)
                {
                    var forecasts = _weatherService.Get(new ForecastRequest()
                    {
                        coords = new ForecastRequest.Coords()
                        {
                            Latitude = city.latitude,
                            Longitude = city.longitude
                        },
                        days = 2
                    }).GetAwaiter().GetResult();

                    string forecastDay1 = forecasts!.forecast.forecastday[0].day.condition.text;
                    string forecastDay2 = forecasts!.forecast.forecastday[1].day.condition.text;

                    Console.WriteLine($"Processed city {city.name} | {forecastDay1} - {forecastDay2}");
                }
            }
            else
            {
                Console.WriteLine("Error retrieving cities");
            }

            Console.WriteLine("-- Press a key to exit --");
            Console.ReadKey();
        }
    }
}