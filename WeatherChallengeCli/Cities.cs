using Newtonsoft.Json;

namespace WeatherChallengeCli.Services
{
    public class Cities
    {
        public string baseApiUrl;

        public Cities(string musementBaseApiUrl)
        {
            if (string.IsNullOrWhiteSpace(musementBaseApiUrl))
            {
                throw new Exception($"{nameof(musementBaseApiUrl)} is required");
            }

            baseApiUrl = musementBaseApiUrl;
        }

        /// <summary>
        /// Retrieve cities from TUI Musement api (only first page of results)
        /// </summary>
        public async Task<CitiesResponse?> Get()
        {
            try
            {
                string citiesApiUrl = $"{baseApiUrl}/api/v3/cities";

                var citiesStr = await Utils.ApiGet(citiesApiUrl);
                if (!string.IsNullOrWhiteSpace(citiesStr))
                {
                    var result = new CitiesResponse();

                    result.Cities = JsonConvert.DeserializeObject<CitiesResponse.City[]>(citiesStr);
                    return result;
                }
            }
            catch (Exception ex)
            {
                // Here we can also log to file the real exception "ex"
                throw new Exception("CitiesRequest: error retrieving the cities list");
            }

            return null;
        }

        public class CitiesResponse
        {
            public City[] Cities { get; set; }

            public class City
            {
                public int id { get; set; }
                public Guid uuid { get; set; }
                public bool top { get; set; }
                public string name { get; set; }
                public string code { get; set; }
                public string content { get; set; }
                public string meta_description { get; set; }
                public string more { get; set; }
                public int weight { get; set; }
                public double latitude { get; set; }
                public double longitude { get; set; }
                public Country country { get; set; }
                public string cover_image_url { get; set; }
                public string url { get; set; }
                public int activities_count { get; set; }
                public string time_zone { get; set; }
                public int list_count { get; set; }
                public int venue_count { get; set; }
                public bool show_in_popular { get; set; }

                public class Country
                {
                    public int id { get; set; }
                    public string name { get; set; }
                    public string iso_code { get; set; }
                }
            }
        }
    }
}