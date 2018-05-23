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

    }
}