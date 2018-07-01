﻿using System;
using System.Threading.Tasks;
using System.Web.Http;
using PubsSubFunctions.Helpers;

namespace PubsSubFunctions.Controllers
{
    public class FunctionsController : ApiController
    {
        public async Task<object> Get(string functionName)
        {
            if (functionName.Equals("AnalyzeImage", StringComparison.CurrentCultureIgnoreCase))
            {
                var image = Resources.identification1;
                return await CognitiveServices.AnalyzeImage(image);
            }
            if (functionName.Equals("FaceDetect", StringComparison.CurrentCultureIgnoreCase))
            {
                var image = Resources.identification1;
                return await CognitiveServices.DetectFaces(image);
            }
            return null;
        }
    }
}