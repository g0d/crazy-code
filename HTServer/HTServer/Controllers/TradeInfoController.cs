/*
    Hyper Trader Server (HTServer)

    Coded by: George Delaportas (G0D)

*/

using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Http.Cors;
using CPM_STARS___Trade_Server.App_Start;

namespace CPM_STARS___Trade_Server.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TradeInfoController : ApiController
    {
        // Enable only on POST request to avoid caching and perform with unlimited data stream
        [HttpPost]
        public string Fetch()
        {
            return JsonConvert.SerializeObject(HTServer.ReturnAggregatedResults());
        }
    }
}
