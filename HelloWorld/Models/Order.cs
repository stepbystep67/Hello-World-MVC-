using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWorld.Models;
using HelloWorld.Controllers;
using System.Data.Entity;

namespace HelloWorld.Models
{

    public class Order
    {
        
        // accesseur automatic depuis le visual studio 2017
        public int Id { get; set; }
        
        public int IdClient { get; set; }

        public DateTime OrderDate { get; set; }

        public double OrderAmount { get; set; }

        public bool OrderPaid { get; set; }
        
        // liste pour gerer plusieur commande 
        // composition avec la class orderline !!!!!
        public List<OrderLine> Items { get; protected set; }  // liste temporaire 

        private Dal dal;
        
        public Order()
        {

            dal = new Dal();

        }

        public Order(int Quantity,double Price)
        {
            
            return;
        }

    }

}
