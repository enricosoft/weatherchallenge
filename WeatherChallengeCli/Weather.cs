using Newtonsoft.Json;

namespace WeatherChallengeCli.Services
{
    public class Weather
    {
        private string weatherApiKey;
        internal static readonly string weatherBaseApiUrl = "http://api.weatherapi.com";

        public Weather(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new Exception($"{nameof(apiKey)} is required");
            }

            weatherApiKey = apiKey;
        }

        /// <summary>
        /// Retrieve weather forecast for given coords and N days, starting from today
        /// </summary>
        public async Task<ForecastResponse?> Get(ForecastRequest request)
        {
            if (request.days <= 0)
            {
                throw new Exception($"{nameof(request.days)} parameter must be greater than zero");
            }
            if (request.coords == null)
            {
                throw new Exception($"{nameof(request.coords)} parameter must be filled");
            }
            else
            {
                if (request.coords.Latitude < -90 || request.coords.Latitude > 90)
                {
                    throw new Exception($"{nameof(request.coords.Latitude)} value is invalid! Must be between -90/90");
                }

                if (request.coords.Longitude < -180 || request.coords.Longitude > 180)
                {
                    throw new Exception($"{nameof(request.coords.Longitude)} value is invalid! Must be between -180/180");
                }
            }

            try
            {
                string _lat = request.coords.Latitude.ToString().Replace(",", ".");
                string _lon = request.coords.Longitude.ToString().Replace(",", ".");

                string weatherForCityApiUrl = $"{weatherBaseApiUrl}/v1/forecast.json?key={weatherApiKey}&q={_lat},{_lon}&days={request.days}&aqi=no&alerts=no";

                string resultStr = await Utils.ApiGet(weatherForCityApiUrl);
                if (!string.IsNullOrWhiteSpace(resultStr))
                {
                    var result = JsonConvert.DeserializeObject<ForecastResponse>(resultStr);
                    return result;
                }
            }
            catch (Exception ex)
            {
                // Here we can also log to file the real exception "ex"
                throw new Exception("GetWeatherForCity: error retrieving the weather forecast");
            }

            return null;
        }
    }

    public class ForecastRequest
    {
        public Coords coords { get; set; }
        public int days { get; set; }

        public class Coords
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }           
        }
    }

    public class ForecastResponse
    {
        public Location location { get; set; }
        public dynamic current { get; set; }
        public Forecast forecast { get; set; }

        public class Forecast
        {
            public ForecastDay[] forecastday { get; set; }

            public class ForecastDay
            {
                public string date { get; set; }
                public long date_epoch { get; set; }
                public Day day { get; set; }
                public dynamic astro { get; set; }
                public dynamic hour { get; set; }

                public class Day
                {
                    public double maxtemp_c { get; set; }
                    public double maxtemp_f { get; set; }
                    public double mintemp_c { get; set; }
                    public double mintemp_f { get; set; }
                    public double avgtemp_c { get; set; }
                    public double avgtemp_f { get; set; }
                    public double maxwind_mph { get; set; }
                    public double maxwind_kph { get; set; }
                    public double totalprecip_mm { get; set; }
                    public double totalprecip_in { get; set; }
                    public double avgvis_km { get; set; }
                    public double avgvis_miles { get; set; }
                    public double avghumidity { get; set; }
                    public double daily_will_it_rain { get; set; }
                    public double daily_chance_of_rain { get; set; }
                    public double daily_will_it_snow { get; set; }
                    public double daily_chance_of_snow { get; set; }
                    public Condition condition { get; set; }
                    public double uv { get; set; }

                    public class Condition
                    {
                        public string text { get; set; }
                        public string icon { get; set; }
                        public int code { get; set; }
                    }
                }
            }
        }

        public class Location
        {
            public string name { get; set; }

            public string region { get; set; }
            public string country { get; set; }

            public double lat { get; set; }
            public double lon { get; set; }
            public string tz_id { get; set; }
            public long localtime_epoch { get; set; }
            public string localtime { get; set; }
        }
    }
}