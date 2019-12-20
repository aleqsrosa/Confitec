using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjetoTeste.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            config.Routes.MapHttpRoute(
             name: "GetWarnings",
             routeTemplate: "api/{controller}/GetWarnings",
             defaults: new { id = RouteParameter.Optional, action = "GetWarnings" }
            );

            config.Routes.MapHttpRoute(
               name: "ExecuteAsync",
               routeTemplate: "api/{controller}/ExecuteAsync",
               defaults: new { id = RouteParameter.Optional, action = "ExecuteAsync" }
            );

            config.Routes.MapHttpRoute(
              name: "ExecuteAsyncMany",
              routeTemplate: "api/{controller}/ExecuteAsyncMany",
              defaults: new { id = RouteParameter.Optional, action = "ExecuteAsyncMany" }
           );

            config.Routes.MapHttpRoute(
                name: "PostMany",
                routeTemplate: "api/{controller}/PostMany",
                defaults: new { id = RouteParameter.Optional, action = "PostMany" }
            );

            config.Routes.MapHttpRoute(
                name: "GetByModel",
                routeTemplate: "api/{controller}/GetByModel",
                defaults: new { id = RouteParameter.Optional, action = "GetByModel" }
            );


            config.Routes.MapHttpRoute(
                name: "GetDetails",
                routeTemplate: "api/{controller}/GetDetails",
                defaults: new { id = RouteParameter.Optional, action = "GetDetails" }
            );

            config.Routes.MapHttpRoute(
                name: "GetReport",
                routeTemplate: "api/{controller}/GetReport",
                defaults: new { id = RouteParameter.Optional, action = "GetReport" }
            );


            config.Routes.MapHttpRoute(
                name: "GetTotalByFilters",
                routeTemplate: "api/{controller}/GetTotalByFilters",
                defaults: new { id = RouteParameter.Optional, action = "GetTotalByFilters" }
            );

            config.Routes.MapHttpRoute(
                name: "GetDataListCustom",
                routeTemplate: "api/{controller}/GetDataListCustom",
                defaults: new { id = RouteParameter.Optional, action = "GetDataListCustom" }
            );

            config.Routes.MapHttpRoute(
                name: "GetDataCustom",
                routeTemplate: "api/{controller}/GetDataCustom",
                defaults: new { id = RouteParameter.Optional, action = "GetDataCustom" }
            );


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/{action}",
                defaults: new { id = RouteParameter.Optional, action = "DefaultAction" }
            );
        }
    }
}
