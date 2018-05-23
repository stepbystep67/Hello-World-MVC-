using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HelloWorld.Controllers
{

    public class HouseController : Controller
    {
        
        // GET: House
        // actionresult return toujours une view
        public ActionResult Index()
        {

            ViewData["nom"] = "justin";

            return View("Vue");

        }

        // id est par defaut null mais si il est defini dans l'url il s'affichera
        // en mettant le parametre id on peut le recuperer 
        public string Salut(String id)
        {

            if(string.IsNullOrEmpty(id))
            {

                 return "Salut les concepteurs";

            }
            
                return "Salut " + id;
                     
        }


        public string Liste()
        {

            return @"<html>
                   <head>
                   <meta charset=""UTF-8"">
                   <title>liste des courses </title>
                   </head>
                   <body>
                   <h1>liste des courses du " + DateTime.Now.ToLongDateString() + @"</h1>
                   <ul>
                   <li>eau</li>
                   <li> lait </li>
                   <li> chevilles &Oslash; 8</li>
                   </ul>
                   </body>
                   </html>
                   ";

        }



    }
}
