﻿using System.Web.Http;
using System.Web.Http.Cors;

namespace EmpApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Enabling the CORS Package
            config.EnableCors(new EnableCorsAttribute("http://localhost:4200", headers: "*", methods:"*"));

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
