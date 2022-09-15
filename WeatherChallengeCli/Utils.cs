using Microsoft.Extensions.Configuration;

namespace WeatherChallengeCli
{
    public static class Utils
    {
        private static HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Perform GET request to api url
        /// </summary>
        public static async Task<string> ApiGet(string apiUrl)
        {
            using (HttpResponseMessage response = await httpClient.GetAsync(apiUrl))
            {
                if (response.IsSuccessStatusCode)
                {
                    string resultContentString = await response.Content.ReadAsStringAsync();
                    return resultContentString;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Get settings from Config.json file
        /// </summary>
        public static IConfigurationRoot GetSettings()
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("Config.json", false, true)
                    .Build();

            return configuration;
        }
    }
}