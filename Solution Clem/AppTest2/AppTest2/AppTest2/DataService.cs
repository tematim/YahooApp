using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AppTest2
{
    public class DataService
    {
        public async static Task<AppTest2.WeatherRequest.Results> getWeather(string woeid)
        {
            MediaTypeWithQualityHeaderValue jsonHeader = new MediaTypeWithQualityHeaderValue("application/json");

            using (var client = new HttpClient() { BaseAddress = new Uri ("http://query.yahooapis.com/")})
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(jsonHeader);
                string query = string.Format("v1/public/yql?q=select+*+from+weather.forecast+where+woeid={0}{1}", woeid, "&format=json");
                HttpResponseMessage apiResponse = await client.GetAsync(query).ConfigureAwait(false);

                if (apiResponse.IsSuccessStatusCode)
                {
                    var result = await apiResponse.Content.ReadAsStringAsync();

                    AppTest2.WeatherRequest.Results data = JsonConvert.DeserializeObject<WeatherRequest.WeatherRequest>(result).query.results;
                    return data;
                }
                return null;
            }
        }

        public async static Task<AppTest2.CityRequest.Results> getCities(string cityName)
        {
            MediaTypeWithQualityHeaderValue jsonHeader = new MediaTypeWithQualityHeaderValue("application/json");

            using (var client = new HttpClient() { BaseAddress = new Uri("http://query.yahooapis.com/") })
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(jsonHeader);
                string query = string.Format("v1/public/yql?q=select * from geo.places(0,5) where text%3D\"{0}\"{1}", cityName, "&format=json");
                HttpResponseMessage apiResponse = await client.GetAsync(query).ConfigureAwait(false);

                if (apiResponse.IsSuccessStatusCode)
                {
                    var result = await apiResponse.Content.ReadAsStringAsync();

                    AppTest2.CityRequest.Results data = JsonConvert.DeserializeObject<AppTest2.CityRequest.CityRequest>(result).query.results;
                    return data;
                }
                return null; 
            }
        }

    }
}
