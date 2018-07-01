using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using PubsSubFunctions.Helpers;

namespace PubsSubFunctions.Controllers
{
    public class FaceDetectController : ApiController
    {
        // GET api/<controller>
        public async Task<object> Get()
        {
            var image = Resources.identification1;
            var result = await CognitiveServices.MakeAnalysisRequest(image);
            return result;
        }

        // GET api/<controller>/5
        public JObject Get(int id)
        {
            return JObject.FromObject("value");
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }


    }
}