using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherChallengeCli.Services;

namespace WeatherChallengeCli.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestWeatherInMilanForNextTwoDays()
        {
            var settings = Utils.GetSettings();
            var milanCoords = new ForecastRequest.Coords()
            {
                Latitude = 45.463619,
                Longitude = 9.188120
            };

            Weather w = new Weather(settings["AppSettings:WeatherApiKey"]);
            var forecastResult = w.Get(new ForecastRequest()
            {
                coords = milanCoords,
                days = 2
            }).GetAwaiter().GetResult();

            bool isValid = forecastResult != null && forecastResult.forecast.forecastday.Length == 2;
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void TestCities()
        {
            var settings = Utils.GetSettings();
            Cities c = new Cities(settings["AppSettings:MusementBaseApiUrl"]);
            var citiesResult = c.Get().GetAwaiter().GetResult();

            bool isValid = citiesResult != null && citiesResult.Cities.Length > 0;
            Assert.IsTrue(isValid);
        }
    }
}