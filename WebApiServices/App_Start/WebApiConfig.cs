﻿using System.Web.Http;
using System.Web.Http.Cors;
using WebApiServices.Controllers;

namespace WebApiServices
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            var cors = new EnableCorsAttribute(origins: "*", headers: "*", methods: "*");

            config.EnableCors(cors);
            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.MessageHandlers.Add(new TokenValidationHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
