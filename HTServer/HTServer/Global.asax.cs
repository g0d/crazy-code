/*
    Hyper Trader Server (HTServer)

    Coded by: George Delaportas (G0D)

*/

using System.Web.Http;

namespace CPM_STARS___Trade_Server
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
