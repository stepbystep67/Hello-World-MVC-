﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// data access layer
// aussi appeler dao = data acces object
// fais le lien entre le model c# et celui asp.net
namespace HelloWorld.Models
{

    // Une classe de base qui implémente IDisposable. 
    // En implémentant IDisposable, vous annoncez que 
    // les instances de ce type allouent des ressources rares.
    // heritage de  : sous class
    public class Dal : IDisposable
    {

        private BddContext db;

        // constructeur par defaut
        public Dal()
        {

            db = new BddContext();

        }

        // grace a : IDisposable !
        // https://msdn.microsoft.com/fr-fr/library/system.idisposable.dispose(v=vs.110).aspx
        // Exécute les tâches définies par l'application associées à la libération ou à la redéfinition des ressources non managées.
        public void Dispose()
        {

            db.Dispose();

        }

        #region PRODUCTS

        // obtient la liste des produits
        public List<Product> GetProduct()
        {

            // type dbset converti
            return db.Products.ToList();

        }

        // ajoute un produit
        public void AddProduct(Product p)
        {

            db.Products.Add(p); // derriere il fait des vrai requete sql donc on peut pas envoyer n'importe quoi 
            db.SaveChanges(); 
            
        }

        // obtient un produit avec identifiant unique
        public Product GetProduct(int id)
        {

            // retourne le produit correspondant 
            return db.Products.FirstOrDefault(x => (x.Id == id)); 
        }

        // obtient la liste 
        public List<Product> GetProducts(Predicate<Product> predicate)
        {


            List<Product> result = new List<Product>();
                
            // pour chaque produit qui passe dans la liste 
            foreach(Product p in db.Products)
            {
                
                if(predicate(p))
                {

                    result.Add(p);

                }

            }

            return result ;
        }

        // mise a jour du produit selectionner 
        public void UpDateProduct(Product p)
        {

            // creation d'un produit que l'on va comparer avec sont equivalent  
            Product exist = db.Products.FirstOrDefault( x => (x.Id == p.Id));

            // preferer cette syntaxe mieux que comparer a null
            if(exist != default(Product))
            {

                // remplacement des données (modification ou mise a jour)
                exist.ProductName = p.ProductName;
                exist.ProductDescription = p.ProductDescription;
                exist.ProductPrice = p.ProductPrice;
               
            }

            
        }

        // supprime un produit 
        public void DeleteProduct(int id)
        {

            // 
            Product exist = db.Products.FirstOrDefault(x => (x.Id == id));
            
            if(exist != default(Product))
            {
                // acces a la base de donnée + model + methode(objet a supprimer)
                db.Products.Remove(exist);

            }

        }


        #endregion

        #region Client

        // obtient la liste de client 
        public List<Client> GetClients()
        {

            // type dbset converti
            return db.Clients.ToList();

        }

        // obtient le client par identifiant unique 
        public Client GetClient(int id)
        {


            return db.Clients.FirstOrDefault(x => (x.Id == id));
        }

        // ajoute un client a la liste 
        public void AddClient(Client c)
        {

            db.Clients.Add(c);// derriere il fait des vrai requete sql donc on peut pas envoyer n'importe quoi 
            db.SaveChanges();

        }

        // supprime un client de la liste 
        public void DeleteClient(int id)
        {

            Client exist = db.Clients.FirstOrDefault(x => (x.Id == id));

            if(exist != default(Client))
            {

                // acces a la base de donnée + model + methode(objet)
                db.Clients.Remove(exist);
                
            }

        }
        
        // modifie un client 
        public void UpDateClient(Client c)
        {

            // mets le client correspondant dans exist qui sera utiliser pour cette methode
            Client exist = db.Clients.FirstOrDefault(x => (x.Id == c.Id));

            // si les données client sont differentes de celui par defaut alors 
            if(exist != default(Client))
            {
                // remplacement des données
                exist.Nom = c.Nom;
                exist.Prenom = c.Prenom;

            }

          // sinon pas de changement 

        }

        // obtient la liste 
        public List<Client> GetClients(Predicate<Client> predicate)
        {

            List<Client> result = new List<Client>();

            // pour chaque client dans la liste 
            foreach(Client c in db.Clients)
            {

                // test du predicate sur le client si true
                if(predicate(c))
                {

                    // alors on l'ajoute au resultat
                    result.Add(c);

                }


            }
              
            // retourne le resultat 
            return result;
        }

        #endregion

    }

}
