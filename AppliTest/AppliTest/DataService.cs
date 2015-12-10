using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AppliTest
{
    internal class DataService
    {
        public static async Task<dynamic> GetDataFromService(string queryString)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(queryString);

            var response = await request.GetResponseAsync().ConfigureAwait(false);
            var stream = response.GetResponseStream();

            var streamReader = new StreamReader(stream);
            string responseText = streamReader.ReadToEnd();

            dynamic data = JsonConvert.DeserializeObject(responseText);

            return data;
        }
    }
}
