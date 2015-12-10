using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliTest
{
    public class Core
    {
        public static async Task<Weather> GetWeather(string zipCode)
        {
            string queryString = "http://query.yahooapis.com/v1/public/yql?q=select+*+from+weather.forecast+where+location="
                + zipCode + "&format=json";

            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);

            dynamic weatherOverview = results["query"]["results"]["channel"];

            if ((string)weatherOverview["description"] != "Yahoo! Weather Error")
            {
                Weather w = new Weather();
                w.Title = (string)weatherOverview["description"];

                dynamic wind = weatherOverview["wind"];
                w.Temperature = (string)wind["chill"];
                w.Wind = (string)wind["speed"];

                dynamic atmosphere = weatherOverview["atmosphere"];
                w.Humidity = (string)atmosphere["humidity"];
                w.Visibility = (string)atmosphere["visibility"];

                dynamic sun = weatherOverview["astronomy"];
                w.Sunrise = (string)sun["sunrise"];
                w.Sunset = (string)sun["sunset"];

                dynamic item = weatherOverview["item"];
                w.Image = (string)item["description"];
                int endOfUrl = w.Image.IndexOf("<br />");
                w.Image = w.Image.Substring(0, endOfUrl);
                w.Image = w.Image.Replace("\n<img src=\"", "").Replace("\"/>", "");
                return w;
            }

            return null;
        }
    }
}
