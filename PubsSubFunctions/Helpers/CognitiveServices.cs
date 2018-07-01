using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PubsSubFunctions.Helpers
{
    public class CognitiveServices
    {
        public static async Task<object> DetectFaces(Image image)
        {
            return await RequestService(Config.FaceDetectApiUri, Config.FaceApiKey, image);
        }

        public static async Task<object> AnalyzeImage(Bitmap image)
        {
            return await RequestService(Config.AnalyzeImageApiUri, Config.ComputerVisionApiKey, image);
        }

        public static async Task<object> DetectPrintedText(Image image)
        {
            return await RequestService(Config.OcrApiUri, Config.ComputerVisionApiKey, image);
        }

        public static async Task<object> DetectHandwritingText(Image image)
        {
            return await RequestService(Config.HandwrittenApiUri, Config.ComputerVisionApiKey, image);
        }

        private static async Task<object> RequestService(string apiUri, string apiKey, Image image)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
            var requestParameters = "visualFeatures=Categories,Description,Color";
            var uri = apiUri + "?" + requestParameters;
            HttpResponseMessage response;
            var byteData = image.ToByteArray(ImageFormat.Jpeg);
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);
            }
            var contentString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(contentString);
        }
    }
}