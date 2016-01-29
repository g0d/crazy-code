using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Crazy_Cards
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{income}/{status}",
                defaults: new { income = RouteParameter.Optional, status = RouteParameter.Optional }
            );
        }
    }
}
