using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Models
{

    public class OrderLine
    {

        private int id;

        private int idOrder;

        private int idProduct;

        private int quantity;

        private double price;

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

        public int IdOrder
        {
            get
            {
                return idOrder;
            }

            set
            {
                idOrder = value;
            }
        }

        public int IdProduct
        {
            get
            {
                return idProduct;
            }

            set
            {
                idProduct = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public OrderLine()
        {



        }
            
        
    }

}