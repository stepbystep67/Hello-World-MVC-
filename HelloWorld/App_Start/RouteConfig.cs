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

            // https://haacked.com/archive/2008/07/14/make-routing-ignore-requests-for-a-file-extension.aspx/
            // Les fichiers axd n'existent pas physiquement. ASP.NET utilise des URL avec des extensions .axd (ScriptResource.axd et WebResource.axd) en interne et elles sont gérées par un HttpHandler.
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // https://docs.microsoft.com/fr-fr/aspnet/core/mvc/controllers/routing?view=aspnetcore-2.1
            // Ceci a pour effet d’instancier le contrôleur HomeController  et d’exécuter la méthode
            routes.MapRoute(name: "Default",url: "{controller}/{action}/{id}",defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });

        }

    }

}
