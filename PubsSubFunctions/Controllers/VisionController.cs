using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using PubsSubFunctions.Models;

namespace PubsSubFunctions.Controllers
{
    public class VisionController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new[] { "AnalyzeImage", "DetectFaces", "DetectPrintedText", "DetectHandwritingText" };
        }

        // GET api/<controller>/5
        public async Task<JObject> Get(string id)
        {
            if (id.Equals("AnalyzeImage", StringComparison.CurrentCultureIgnoreCase))
            {
                var image = Resources.identification1;
                return await ImageServices.AnalyzeImage(image);
            }
            if (id.Equals("DetectFaces", StringComparison.CurrentCultureIgnoreCase))
            {
                var image = Resources.identification1;
                return await ImageServices.DetectFaces(image);
            }
            if (id.Equals("DetectPrintedText", StringComparison.CurrentCultureIgnoreCase))
            {
                var image = Resources.PrintedText;
                return await ImageServices.DetectPrintedText(image);
            }
            if (id.Equals("DetectHandwritingText", StringComparison.CurrentCultureIgnoreCase))
            {
                var image = Resources.PrintedText;
                return await ImageServices.DetectHandwritingText(image);
            }

            return null;
        }
    }
}