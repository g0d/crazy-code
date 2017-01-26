/*
    Hyper Trader Server (HTServer)

    Coded by: George Delaportas (G0D)

*/

using System.Web.Http;
using CPM_STARS___Trade_Server.App_Start;

namespace CPM_STARS___Trade_Server
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Enable CORS
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
            name: "TradeServer",
            routeTemplate: "service/{controller}/{action}"
            );

            // Run Hyper Trader Server
            HTServer.Run();
        }
    }
}
