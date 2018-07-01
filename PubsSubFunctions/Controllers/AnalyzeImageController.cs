using System.Threading.Tasks;
using System.Web.Http;
using PubsSubFunctions.Helpers;

namespace PubsSubFunctions.Controllers
{
    public class AnalyzeImageController : ApiController
    {
        // GET api/<controller>
        public async Task<object> Get()
        {
            var image = Resources.identification1;
            var result = await CognitiveServices.AnalysisImage(image);
            return result;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
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