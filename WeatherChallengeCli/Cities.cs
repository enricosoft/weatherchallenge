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
        public async Task Get()
        {
            string citiesApiUrl = $"{baseApiUrl}/api/v3/cities";

            // TODO
        }
    }
}