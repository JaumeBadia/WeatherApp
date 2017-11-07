using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Challenge1_2.Models;
using Newtonsoft.Json;

namespace Challenge1_2.Helpers
{
    public class WeatherHelper
    {
        const string API_URL = "http://traininglabservices.azurewebsites.net/api/weather/";

        public async static Task<WeatherInformation> GetCurrentConditionsAsync(double latitude, double longitude)
        {
            string url = $"{API_URL}current?latitude={latitude}&longitude={longitude}&registrationCode={App.RegistrationCode}";

            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<WeatherInformation>(response);
            return result;
        }

        public async static Task<WeatherInformation> GetCurrentConditionsAsync(string cityName, string countryCode)
        {
            string url = $"{API_URL}current/city?cityName={cityName}&countryCode={countryCode}&registrationCode={App.RegistrationCode}";

            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<WeatherInformation>(response);
            return result;
        }

        public async static Task<List<WeatherInformation>> GetForecastAsync(double latitude, double longitude)
        {
            string url = $"{API_URL}forecast?latitude={latitude}&longitude={longitude}&registrationCode={App.RegistrationCode}";

            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<List<WeatherInformation>>(response);
            return result;
        }

        public async static Task<List<WeatherInformation>> GetForecastAsync(string cityName, string countryCode)
        {
            string url = $"{API_URL}forecast/city?cityName={cityName}&countryCode={countryCode}&registrationCode={App.RegistrationCode}";

            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<List<WeatherInformation>>(response);
            return result;
        }

    }
}

