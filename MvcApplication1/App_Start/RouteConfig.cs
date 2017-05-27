using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.MapRoute("Article", "article/view/{heading}",
            defaults: new { controller = "Article", action = "Details", heading = UrlParameter.Optional });

            routes.MapRoute("Category", "category/{category}",
            defaults: new { controller = "Category", action = "Category", category = UrlParameter.Optional });

            routes.MapRoute("Users", "author/{username}",
            defaults: new { controller = "Users", action = "Details", username = UrlParameter.Optional });

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}