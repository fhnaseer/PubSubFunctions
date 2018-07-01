using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using PubsSubFunctions.Models;

namespace PubsSubFunctions.Controllers
{
    public class TextController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new[] { "DetectLanguage" };
        }

        // GET api/<controller>/5
        public async Task<object> Get(string id)
        {
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