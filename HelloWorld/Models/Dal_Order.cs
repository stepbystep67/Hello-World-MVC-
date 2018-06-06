using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Models
{

    // Une classe de base qui implémente IDisposable. 
    // En implémentant IDisposable, vous annoncez que 
    // les instances de ce type allouent des ressources rares.
    // heritage de  : sous class
    public class Dal_Order : IDisposable
    {

        private BddContext db;

        public Dal_Order()
        {

            db = new BddContext();

        }


        public void dispose()
        {

            db.Dispose();

        }



    }

}