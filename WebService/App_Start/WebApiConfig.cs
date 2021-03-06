﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

                        // Rotas da API da Web
            var politicas = new EnableCorsAttribute(
            origins: "*",
            methods: "*",
            headers: "*"
            );
            config.Filters.Add(new AuthorizeAttribute());
            config.EnableCors(politicas);
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
