using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// https://openclassrooms.com/courses/apprendre-asp-net-mvc/hello-world-mvc

namespace HelloWorld.Controllers
{

    public class HomeController : Controller
    {

        // action par defaut defini dans le routeconfig
        // GET: Home
        public string Index()
        {

            return "<a href=\"/client/\">Hello World</a>";

        }

        public string Bonjour()
        {

            return "Bonjour les développeurs";

        }

        public string Index2(int? id)
        {

            return "hello " + id ;

        }

    }
}