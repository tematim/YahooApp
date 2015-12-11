using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTest2
{
    public class Core
    {
        public static AppTest2.WeatherRequest.Channel GetWeather(string cityName)
        {
            var result = DataService.getWeather(cityName).Result.channel;
            if (result != null)
            {
                return result;
            }
            return null;
        }



        public static List<AppTest2.CityRequest.Place> GetCities(string cityName)
        {
            AppTest2.CityRequest.Results result = DataService.getCities(cityName).Result;
            if (result != null)
                return result.place;
            else
                return null;
        }

        public static AppTest2.CityRequest.Place GetCity(string cityName)
        {
            AppTest2.CityRequest.Results result = DataService.getCities(cityName).Result;
            if (result != null)
                return result.place.First();
            else
                return null;
        }


    }
}
