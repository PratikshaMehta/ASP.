using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace EmployeeSkillsManager
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
        //    var jsonFormatter = configuration.Formatters.OfType<JsonMediaTypeFormatter>().First();
        //    jsonFormatter.SerializerSettings.ContractResolver =
        //      new CamelCasePropertyNamesContractResolver();

            configuration.MapHttpAttributeRoutes();
            configuration.Routes.MapHttpRoute(
                      name: "DefaultApi",
                      routeTemplate: "api/{controller}/{id}",
                      defaults: new { id = RouteParameter.Optional }
                    
                  );

        }
    }
    }

