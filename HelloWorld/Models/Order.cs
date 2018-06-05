using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWorld.Models;
using HelloWorld.Controllers;


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
        public List<product> Items { get; protected set; }// liste temporaire 

        Dal dal;

        OrderLine order_line;

        public Order()
        {



        }

        public Order(int id,int idclient,DateTime orderdate,double ordermount,bool orderpaid)
        {

            this.Id = id;
            this.OrderDate = orderdate;
            this.OrderAmount = ordermount;
            this.OrderPaid = orderpaid;

        }

    }

}