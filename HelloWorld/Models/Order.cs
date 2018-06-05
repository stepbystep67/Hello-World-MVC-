using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Models
{

    public class Order
    {

        private int id; // identifiant unique pour chaque personne

        private int amount; // montant sans taxe 
       
        private int total_tax;//montant avec taxe 
        
        private Client client; // client temporaire 

        private List<Product> list; // liste temporaire 

        private int idClient;

        private DateTime orderTime;

        private double orderAmount;

        private bool orderPaid; 

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public int Total_tax
        {
            get
            {
                return total_tax;
            }

            set
            {
                total_tax = value;
            }
        }

        public Client Client
        {
            get
            {
                return client;
            }

            set
            {
                client = value;
            }
        }

        public List<Product> List
        {
            get
            {
                return list;
            }

            set
            {
                list = value;
            }
        }

        public int IdClient
        {
            get
            {
                return idClient;
            }

            set
            {
                idClient = value;
            }
        }

        public DateTime OrderTime
        {
            get
            {
                return orderTime;
            }

            set
            {
                orderTime = value;
            }
        }

        public double OrderAmount
        {
            get
            {
                return orderAmount;
            }

            set
            {
                orderAmount = value;
            }
        }

        public bool OrderPaid
        {
            get
            {
                return orderPaid;
            }

            set
            {
                orderPaid = value;
            }
        }

        public Order()
        {



        }

    }
}