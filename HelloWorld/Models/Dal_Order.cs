using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Helpers;
using HelloWorld.Models;
using System.Web.Mvc;



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

        
        public void Dispose()
        {

            // libere les ressources
            db.Dispose();

        }

        #region Order

        // affiche la liste de commande 
        public List<Order> GetOrders()
        {
            
            return db.Orders.ToList();
        }

        // affiche un commande avec un id 
        public Order GetOrder(int id)
        {

            return db.Orders.FirstOrDefault(x => (x.Id == id));

        }

        // affiche les commandes
        public void AddOrder()
        {



        }

        // ajoute un produit 
        public void AddOrder(Order o)
        {

            db.Orders.Add(o);
            db.SaveChanges();

        }

        public void Delete()
        {

            
        }

        // supprime la commande selectionner 
        public void DeleteOrder(int id)
        {

            Order o = db.Orders.FirstOrDefault(x => (x.Id == id));

            if(o != default(Order))
            {

                db.Orders.Remove(o);
                db.SaveChanges();

            }

        }

        // mets a jour les données de la commande 
        public void UpDateOrder(Order o)
        {

            Order order = db.Orders.FirstOrDefault(x => (x.Id == o.Id));

            if(order != default(Order))
            {

                order.Id = o.Id;
                order.IdClient = o.IdClient;
                order.OrderDate = o.OrderDate;
                order.OrderAmount = o.OrderAmount;
                order.OrderPaid = order.OrderPaid;
                db.SaveChanges();

            }

        }


        #endregion

        #region OrderLine

        #endregion
    }

}
