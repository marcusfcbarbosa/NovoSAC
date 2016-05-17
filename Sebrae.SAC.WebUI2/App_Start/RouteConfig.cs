﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sebrae.SAC.WebUI2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Properties",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Acesso", action = "LoginPeloAd", id = UrlParameter.Optional }
            );
        }
    }
}