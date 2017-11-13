using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Challenge1_2.Models;
using Newtonsoft.Json;

namespace Challenge1_2.Helpers
{
    public class WeatherHelper
    {
        const string API_URL = "api.openweathermap.org/data/2.5/";
        const string APIKEY = "82f68294db2203d8329612af936d068b";

        public static async Task<WeatherInformation.ResponseWeather> GetCurrentConditionsAsync(double lat, double lon)
        {
            string url = $"http://{API_URL}weather?lat={lat}&lon={lon}&APPID={APIKEY}";

            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<WeatherInformation.ResponseWeather>(response);
            return result;
        }

        public static async Task<WeatherInformation.ResponseWeather> GetCurrentConditionsAsync(string name, string country)
        {
            string url = $"http://{API_URL}weather?q={name},{country}&APPID={APIKEY}";

            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<WeatherInformation.ResponseWeather>(response);
            return result;
        }

        public static async Task<List<WeatherInformation.ResponseWeather>> GetForecastAsync(double lat, double lon)
        {
            string url = $"http://{API_URL}forecast?lat={lat}&lon={lon}&APPID={APIKEY}";

            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<List<WeatherInformation.ResponseWeather>>(response);
            return result;
        }

        public static async Task<List<WeatherInformation.ResponseWeather>> GetForecastAsync(string name, string country)
        {
            string url = $"http://{API_URL}forecast?q={name},{country}&APPID={APIKEY}";

            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<List<WeatherInformation.ResponseWeather>>(response);
            return result;
        }
    }
}

