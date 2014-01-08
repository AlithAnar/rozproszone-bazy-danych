using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace rozproszone_bazy_danych
    {
    public class RouteConfig
        {
        public static void RegisterRoutes(RouteCollection routes)
            {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "CityList",
               url: "User/City/List/{Id}",
               defaults: new { controller = "User", action = "CityList", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "ProvinceList",
               url: "User/Province/List",
               defaults: new { controller = "User", action = "ProvinceList", id = UrlParameter.Optional }
           );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            }
        }
    }