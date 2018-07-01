namespace PubsSubFunctions.Helpers
{
    public static class Config
    {
        //public const string FaceApiKey = "96d2edaafbf94584a641b6af273fed54";
        //public const string FaceApiUriBase = "https://westeurope.api.cognitive.microsoft.com/face/v1.0/detect";
        public const string FaceApiKey = "60c58d2cd10849169e49e43e3ec320db";
        public const string FaceApiUriBase = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/";
        public static string FaceDetectApiUri = FaceApiUriBase + "detect";
    }
}