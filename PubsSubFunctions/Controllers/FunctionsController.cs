using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using PubsSubFunctions.Models;

namespace PubsSubFunctions.Controllers
{
    public class FunctionsController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public async Task<object> Get(string id)
        {
            if (id.Equals("AnalyzeImage", StringComparison.CurrentCultureIgnoreCase))
            {
                var image = Resources.identification1;
                return await ImageServices.AnalyzeImage(image);
            }
            if (id.Equals("FaceDetect", StringComparison.CurrentCultureIgnoreCase))
            {
                var image = Resources.identification1;
                return await ImageServices.DetectFaces(image);
            }
            if (id.Equals("PrintedText", StringComparison.CurrentCultureIgnoreCase))
            {
                var image = Resources.PrintedText;
                return await ImageServices.DetectPrintedText(image);
            }
            if (id.Equals("HandwritingText", StringComparison.CurrentCultureIgnoreCase))
            {
                var image = Resources.PrintedText;
                return await ImageServices.DetectHandwritingText(image);
            }

            if (id.Equals("DetectLanguage", StringComparison.CurrentCultureIgnoreCase))
            {
                var query =
                    @"{""documents"":[{""id"":""1"",""text"":""Hello world""},{""id"":""2"",""text"":""Bonjour tout le monde""},{""id"":""3"",""text"":""La carretera estaba atascada. Había mucho tráfico el día de ayer.""},{""id"":""4"",""text"":"":) :( :D""}]}";
                return await TextService.DetectLanguages(query);
            }
            return null;
        }
    }
}
