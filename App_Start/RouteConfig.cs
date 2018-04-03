using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ExemploValidacao
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Todas as Noticias",
                url: "noticias/",
                defaults: new { controller = "Noticia", action = "TodasAsNoticias" }
                );

            routes.MapRoute(
                name: "Notícias de categoria específica",
                url: "Noticias/{categoria}",
                defaults: new { controller = "Noticia", action = "MostraCategoria" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Pessoa", action = "IndexPessoa", id = UrlParameter.Optional }
            );

            
        }
    }
}