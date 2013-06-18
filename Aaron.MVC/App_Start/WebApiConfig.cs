using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Aaron.MVC.Formatters;

namespace Aaron.MVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnableSystemDiagnosticsTracing();

            config.Formatters.Add(new PlainTextMediaTypeFormatter());
        }
    }
}
