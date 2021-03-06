﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Parser.MvcClient
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.LowercaseUrls = true;

            routes.MapRoute(
                name: "Owner",
                url: "owner",
                defaults: new { controller = "Owner", action = "Index" }
            );

            routes.MapRoute(
                name: "Admin",
                url: "admin",
                defaults: new { controller = "Administration", action = "Index" }
            );

            routes.MapRoute(
                name: "TopDps",
                url: "damage",
                defaults: new { controller = "Leaderboard", action = "Damage" }
            );

            routes.MapRoute(
                name: "TopHps",
                url: "healing",
                defaults: new { controller = "Leaderboard", action = "Healing" }
            );

            routes.MapRoute(
                name: "Live",
                url: "live",
                defaults: new { controller = "Live", action = "Index" }
            );

            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new { controller = "Account", action = "Login" }
            );

            routes.MapRoute(
                name: "RemoteLogin",
                url: "remote",
                defaults: new { controller = "RemoteAuth", action = "Login" }
            );

            routes.MapRoute(
                name: "Register",
                url: "register",
                defaults: new { controller = "Account", action = "Register" }
            );

            routes.MapRoute(
                name: "Download",
                url: "download",
                defaults: new { controller = "Home", action = "Download" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
