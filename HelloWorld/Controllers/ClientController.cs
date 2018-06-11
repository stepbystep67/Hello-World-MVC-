using HelloWorld.Models; // acces au contenu du dossier model
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; // https://msdn.microsoft.com/fr-fr/library/system.web.mvc(v=vs.118).aspx

// crud par defaut afficher
// crud = create read update delete modification de donnée 
// une methode pour afficher puis une pour valider !!!

namespace HelloWorld.Controllers
{

    // heritage de la classe controller 
    public class ClientController : Controller
    {

        Dal dal;

        public ClientController()
        {

            dal = new Dal();

        }

        // en static pour chaque instance meme liste !!! et non static une nouvelle liste se creer
        // création de la liste de client 
       static public List<Client> liste = new List<Client>()
        {

                 // ici inserer les clients avec son id , prenom , nom 
                 new Client(1,"Maria","Anders"),
                 new Client(2,"lara","croft"),
                 new Client(3,"Christina ","Berglund"),
                 new Client(4,"justin","alemany"),
                 new Client(5,"Roland ","Mendel")

        };


        Client client = new Client();

        // GET: Client
        public ActionResult Index()
        {
            // redirection vers la prochaine méthode
            return RedirectToAction("Liste");                    // View(dal.GetClients())
        }

        // correspond au clique sur le lien liste des client 
        public ActionResult Liste()
        {
            // retourne donc affiche la liste
            return View(liste);                                   // View(dal.GetClients)

        }

        // une methode pour afficher puis une pour valider !!!
        // affiche le formulair
        public ActionResult Create()
        {

            return View();                                   // View(dal.AddClient())

        }

        // valide le formulair
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Client c)
        {
            // verifier si il y a au moin un client
            if(liste.Count > 0)
            {
               // renvoi le plus grand nombre
               c.Id = liste.Max(x => x.Id) + 1;

            }
            else
            {
                // sinon on lui donne le premier id = 1 
                c.Id = 1;

            }
            

            // si invalide
            if(!ModelState.IsValid)
            {

                // alors on re
                return View("Create", c);                              // View(dal.AddClient());
            }

            // ajout de l'utilisateur 
            liste.Add(c);

            // cette methode s'occupe deja d'afficher la vue
            return RedirectToAction("Liste");

        }

        // identique a edit 
        public ActionResult Delete(int id)
        {

            Client c = liste.FirstOrDefault(x => x.Id == id);

            if(c != default(Client))
            {

                return View(c);                                           // View(dal.Delete());

            }

            return RedirectToAction("liste");
        }


        [HttpPost,ActionName("Delete")]// permet l'uti
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Client c = liste.FirstOrDefault(x => x.Id == id);
            
            if(c != default(Client))
            {

                //  
                if(liste.Remove(c))
                {

                   

                }

                return View();                                           // View(dal.Delete());

            }

            return RedirectToAction("list");

        }


        // le parametre sert a recuperer l'id
        public ActionResult Edit(int id)
        {

            //Client c = new Client();

            //foreach(Client cl in liste)
            //{
            //    if(cl.Id == id)
            //    {
            //        // alors on mets 
            //        c.Id = cl.Id;
            //        c.Prenom = cl.Prenom;
            //        c.Nom = cl.Nom;

            //    }
            
            //}

            // la requete si dessous remplace tout le code au dessus



            // utilise
            // requete linq (nom du moteur de recherche dans c#)
            // renvoi null si il trouve pas 
            Client cc = liste.FirstOrDefault(x => (x.Id == id));

            // si le client 
            if(cc != default(Client))
            {

                return View(cc);

            }

            // sinon on redirige vers la liste a nouveau
            // https://msdn.microsoft.com/fr-fr/library/dd460241(v=vs.118).aspx
            // Effectue une redirection vers l'action spécifiée à l'aide du nom d'action.
            return RedirectToAction("Liste");
        }

        [AcceptVerbs(HttpVerbs.Post)] // permet d'accepter le verb http
        public ActionResult Edit(Client c)// parametre client directement a comparer avec l'id
        {

            // exist represente la variable temporaire de  
            Client exist = liste.FirstOrDefault(x => x.Id == c.Id) ;

            // si il existe dans la liste
            if(exist != default(Client))
            {

                // alors remplacement du prénom et nom !
                exist.Prenom = c.Prenom;
                exist.Nom = c.Nom;
                
            }

            // retourne la liste comme avant d'avoir choisie edit donc avant modication
            return RedirectToAction("liste");

        }

        public ActionResult Details(int id)
        {

            Client c = liste.FirstOrDefault(x => (x.Id == id));

            return View(c);                                                              // view(dal.GetClient)

        }

        
    }

}
