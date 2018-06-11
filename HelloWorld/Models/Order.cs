using System;
using System.Collections.Generic;

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
        protected List<OrderLine> Items;  // liste temporaire 

        List<Order> List_Order { get; set; }

    }

}
