using AppTest2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {


        static void Main(string[] args)
        {

            AppTest2.WeatherRequest.Channel weather = Core.GetWeather("615702");
            var autocompletedCitiesList = new List<AppTest2.CityRequest.Place>();
            string[] autoCompleteOptions = new string[10];

            if ("Marse".Length > 4)
            {
                autocompletedCitiesList = Core.GetCities("Marsei");
                if (autocompletedCitiesList != null)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        autoCompleteOptions[i] = string.Format("{0},{1} / {2}", autocompletedCitiesList[i].name, autocompletedCitiesList[i].country.content, autocompletedCitiesList[i].admin1.content);
                    }
                }
            }

            /*
            Console.WriteLine("Titre : {0}", weather.Title);
            Console.WriteLine("Humidity : {0}", weather.Humidity);
            Console.WriteLine("Sunrise : {0}", weather.Sunrise);
            Console.WriteLine("Sunset : {0}", weather.Sunset);
            Console.WriteLine("Temperature : {0}", weather.Temperature);
            Console.WriteLine("Visibility : {0}", weather.Visibility);
            Console.WriteLine("Wind : {0}", weather.Wind);
            Console.WriteLine("ImageURL : {0}", weather.ImageDescription);
            */
            Console.Read();
        }
    }
}
