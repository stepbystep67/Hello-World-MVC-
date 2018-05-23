using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

// route par defaut 
// si on veut ajouter une route reprendre syntaxe de routes.maproute ! et definir ce qu'on a besoin
namespace HelloWorld
{

    public class RouteConfig
    {

        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Ceci a pour effet d’instancier le contrôleur HomeController  et d’exécuter la méthode
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
