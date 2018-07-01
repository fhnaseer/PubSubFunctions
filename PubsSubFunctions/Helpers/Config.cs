namespace PubsSubFunctions.Helpers
{
    public static class Config
    {
        //public const string FaceApiKey = "96d2edaafbf94584a641b6af273fed54";
        //public const string FaceApiUriBase = "https://westeurope.api.cognitive.microsoft.com/face/v1.0/detect";
        public const string FaceApiKey = "60c58d2cd10849169e49e43e3ec320db";
        public const string ComputerVisionApiKey = "ceed23b3481848b79d3bd9328fb1b2a4";
        public static string FaceDetectApiUri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/detect";

        public const string VisionApiUri = "https://westcentralus.api.cognitive.microsoft.com/vision/v2.0/";
        public static string AnalyzeImageApiUri = VisionApiUri + "analyze";
        public static string OcrApiUri = VisionApiUri + "ocr";
        public static string HandwrittenApiUri = VisionApiUri + "recognizeText";
    }
}