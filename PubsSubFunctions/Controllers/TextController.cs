using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using PubsSubFunctions.Models;
using StringComparison = System.StringComparison;

namespace PubsSubFunctions.Controllers
{
    public class TextController : ApiController
    {
        private const string DetectLanguages = "DetectLanguages";
        private const string DetectKeyPhrases = "DetectKeyPhrases";
        private const string DetectSentiments = "DetectSentiments";

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new[] { DetectLanguages, DetectKeyPhrases, DetectSentiments };
        }

        // GET api/<controller>/5
        public async Task<object> Get(string id)
        {
            var query = new TextInput
            {
                Documents = new List<Document>
                {
                    new Document {Id = "1", Text = "Hello world", Language = "en"},
                    new Document {Id = "2", Text = "Bonjour tout le monde", Language = "fr"},
                    new Document {Id = "3", Text = "La carretera estaba atascada.", Language = "es"}
                }
            };

            if (id.Equals(DetectLanguages, StringComparison.CurrentCultureIgnoreCase))
                return await TextService.DetectLanguages(query);
            if (id.Equals(DetectKeyPhrases, StringComparison.CurrentCultureIgnoreCase))
                return await TextService.DetectKeyPhrases(query);
            if (id.Equals(DetectSentiments, StringComparison.CurrentCultureIgnoreCase))
                return await TextService.DetectSentiments(query);
            return null;
        }
    }
}