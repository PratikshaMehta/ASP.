using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

namespace EmployeeSkillsManagerWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //           GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings
            //.Add(new System.Net.Http.Formatting.RequestHeaderMapping("Accept",
            //                              "text/html",
            //                              StringComparison.InvariantCultureIgnoreCase,
            //                              true,
            //                              "application/json"));
            //           // Web API configuration and services
            //           var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            //           jsonFormatter.SerializerSettings.ContractResolver =
            //             new CamelCasePropertyNamesContractResolver();
            // Web API routes

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            var json = config.Formatters.JsonFormatter;

            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }

            );

            //config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
