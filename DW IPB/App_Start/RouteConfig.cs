using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DW_IPB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Sarjana",
                url: "Akademik/{controller}/{action}/{id}",
                defaults: new { controller = "Sarjana", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Doktor",
                url: "Akademik/{controller}/{action}/{id}",
                defaults: new { controller = "Doktor", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Diploma",
                url: "Akademik/{controller}/{action}/{id}",
                defaults: new { controller = "Diploma", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Master",
                url: "Akademik/{controller}/{action}/{id}",
                defaults: new { controller = "Master", action = "Index", id = UrlParameter.Optional }
            );
            
            
        }
    }
}
