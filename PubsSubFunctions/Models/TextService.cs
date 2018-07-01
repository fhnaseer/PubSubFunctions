using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PubsSubFunctions.Models
{

    public class Document
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }
    }

    public class TextInput
    {
        [JsonProperty("documents")]
        public List<Document> Documents { get; set; }
    }

    public static class TextService
    {
        public static async Task<JObject> DetectLanguages(TextInput query)
        {
            return await RequestService(Config.TextAnalyticsApiKey, Config.DetectLanguagesApiUri, query);
        }

        public static async Task<JObject> DetectKeyPhrases(TextInput query)
        {
            return await RequestService(Config.TextAnalyticsApiKey, Config.DetectKeyPhrasesApiUri, query);
        }

        public static async Task<JObject> DetectSentiments(TextInput query)
        {
            return await RequestService(Config.TextAnalyticsApiKey, Config.DetectSentimentsApiUri, query);
        }

        private static async Task<JObject> RequestService(string apiKey, string apiUri, TextInput query)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
            var uri = apiUri + "?" + queryString;

            var byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(query));
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);
                var contentString = await response.Content.ReadAsStringAsync();
                return JObject.Parse(contentString);
            }
        }
    }
}