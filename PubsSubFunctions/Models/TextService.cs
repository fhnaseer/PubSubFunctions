using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json.Linq;

namespace PubsSubFunctions.Models
{
    public static class TextService
    {
        public static async Task<JObject> DetectLanguages(string query)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Config.TextAnalyticsApiKey);
            var uri = Config.DetectLanguagesApiUri + "?" + queryString;
            HttpResponseMessage response;

            var byteData = Encoding.UTF8.GetBytes(query);
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
            }

            var contentString = await response.Content.ReadAsStringAsync();
            return JObject.Parse(contentString);
        }
    }
}