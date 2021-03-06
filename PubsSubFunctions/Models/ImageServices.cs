﻿using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PubsSubFunctions.Models
{
    public static class ImageServices
    {
        public static async Task<JObject> DetectFaces(Image image)
        {
            return await RequestService(Config.FaceApiKey, Config.FaceDetectApiUri, image);
        }

        public static async Task<JObject> AnalyzeImage(Bitmap image)
        {
            return await RequestService(Config.ComputerVisionApiKey, Config.AnalyzeImageApiUri, image);
        }

        public static async Task<JObject> DetectPrintedText(Image image)
        {
            return await RequestService(Config.ComputerVisionApiKey, Config.OcrApiUri, image);
        }

        public static async Task<JObject> DetectHandwritingText(Image image)
        {
            return await RequestService(Config.ComputerVisionApiKey, Config.HandwrittenApiUri, image);
        }

        private static async Task<JObject> RequestService(string apiKey, string apiUri, Image image)
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
            return JObject.Parse(contentString);
        }
    }
}