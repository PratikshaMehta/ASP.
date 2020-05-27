using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EmployeeSKillsManagerMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "EmployeeSkills", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "EmployeeSKillsManagerMVC.Controllers" });


                 routes.MapRoute("EmployeeSkills",
"EmployeeSkills/Edit/{EmployeeID}/{SkillID}",
new { Controller = "EmployeeSkills", action = "Edit" }


            );
        }
    }
}
