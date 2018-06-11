using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;    // contient des classes et des interfaces qui prennent en charge l'infrastructure ASP.NET MVC (Model View Controller) pour la création d'applications Web. Cet espace de noms inclut des classes qui représentent les contrôleurs, les fabriques de contrôleurs, les résultats d'action, les vues, la vue partielle, les classeurs de modèles et plus encore. https://msdn.microsoft.com/fr-fr/library/system.web.mvc(v=vs.118).aspx
using HelloWorld.Models; // permet l'acces au contenu du dossier models 


namespace HelloWorld.Controllers
{


    public class OrderController : Controller
    {

        // creation de la base de donnée temporaire vide
        Dal_Order dal_order;

        // constructeur par defaut 
        public OrderController()
        {

            // mettre la nouvelle base de donnée dans cette temporaire, ce qui se fera a chaque commande ....
            dal_order = new Dal_Order();

        }
        
        
        // GET: Order
        public ActionResult Index()
        {
            // redirige vers la page par defaut
            return View(dal_order.GetOrders());

        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {

            return View(dal_order);

        }

        // GET: Order/Create
        public ActionResult Create()
        {

            return View();

        }

        // POST: Order/Create
        // Contient les fournisseurs de valeurs de formulaire de l'application.
        // https://stackoverflow.com/questions/762825/how-can-a-formcollection-be-enumerated-in-asp-net-mvc
        // https://docs.microsoft.com/fr-fr/aspnet/core/mvc/controllers/routing?view=aspnetcore-2.1
        // https://msdn.microsoft.com/fr-fr/library/system.web.mvc.formcollection(v=vs.118).aspx
        [HttpPost]// oblige a ne que utiliser la méthode post ... nouvel synaxe ,HttpPostAttribute ([HttpPost]) est une implémentation de IActionConstraint qui permet la sélection de l’action seulement quand le verbe HTTP est POST
        public ActionResult Create(FormCollection collection)// Contient les fournisseurs de valeurs de formulaire de l'application.
        {                         

            try
            {

                // TODO: Add insert logic here
                // on creer une nouvelle commande a chaque click sur create new
                Order order = new Order();
                
                // model.propriete = conversion(collection[champ correspondant utilisateur]);
                // syntaxe pour recuperer et inserer les saisies utilisateurs et mettre dans les proprietes du model order ! 
                order.IdClient = int.Parse(collection["idClient"]);

                order.OrderAmount = double.Parse(collection["OrderAmount"]);

                order.OrderDate = DateTime.Parse(collection["OrderDate"]);

                order.OrderPaid = bool.Parse(collection["OrderPaid"]);

                dal_order.AddOrder(order);
                
                return RedirectToAction("dal_order.GetOrders()");

            }
            catch
            {

                return View(dal_order.GetOrders());

            }

        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {

            return View();

        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            try
            {

                // TODO: Add update logic here
                Order order;
                
                return RedirectToAction("Index");

            }
            catch
            {

                return View();

            }

        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {

            return View();

        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            // recupere la bonne commande
            Order exist = dal_order.GetOrder(id);
            
            try// essaie 
            {
                
                return RedirectToAction("Index");

            }
            catch
            {

                return View();

            }

        }

    }

}
