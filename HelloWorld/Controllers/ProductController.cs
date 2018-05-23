using HelloWorld.Models; // 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HelloWorld.Controllers
{

    public class ProductController : Controller
    {
        // 
        static public List<Product> List_Product = new List<Product>
        {

            // des que l'objet sera creer il rempli automatiquement
            new Product("a001"){ ProductName="license",ProductPrice=123,ProductDescription="1 an toute option"},
            new Product("a002"){ ProductName="anti virus",ProductPrice=321,ProductDescription="6 jours uniquement"},
            new Product("a003"){ ProductName="jeux video",ProductPrice=456,ProductDescription="campeur interdit"},
            new Product("a004"){ ProductName="systeme d'exploitation",ProductPrice=654,ProductDescription="unix "},
            new Product("a005"){ ProductName="cloud",ProductPrice=789,ProductDescription="deux elements seulement"},
            new Product("a006"){ ProductName="quelque chose",ProductPrice=987,ProductDescription="truc"}

        };


        // GET: Product
        public ActionResult Index()
        {

            return View(List_Product);

        }

        public ActionResult Create()
        {


            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Product p)
        {
       

            if (!ModelState.IsValid)
            {


                return View("Create", p);
            }

            List_Product.Add(p);

            // rediriger vers une autre page pour ne pas que l'utilisateur puisse actualiser
            return RedirectToAction("index");

        }


        public ActionResult Delete(string id)
        {

            Product exist = List_Product.FirstOrDefault(x => x.Reference == id);

            if(exist != default(Product))
            {

                return View(exist);

            }

            return RedirectToAction("index");
        }

        [HttpPost, ActionName("Delete")]// permet l'utilisation de
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {

            Product exist = List_Product.FirstOrDefault(x => x.Reference == id);

            if(exist != default(Product))
            {

                if(List_Product.Remove(exist))
                {


                  
                }
                return View(exist);
               
            }
               return RedirectToAction("index");
            
        }


        public ActionResult Edit(string id)
        {

            Product exist = List_Product.FirstOrDefault(x => x.Reference == id);

            if(exist != default(Product))
            {
                
                return View(exist);

            }

           return RedirectToAction("index");
            
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Product p)
        {

            Product exist = List_Product.FirstOrDefault(x => x.Reference == p.Reference);

            if (exist != default(Product))
            {

                exist.ProductName = p.ProductName;
                exist.ProductPrice = p.ProductPrice;
                exist.ProductDescription = p.ProductDescription;

            }

            return RedirectToAction("Index");

        }



        public ActionResult Details(Product _p)
        {

            //  la methode firstordefaut evite de trycatch
            // si il trouve pas de correspondance renvoi null
            Product p = List_Product.FirstOrDefault(x => (x.Reference == _p.Reference));

            // on s'assure que le type est le bon 
            if(p != default(Product))
            {

                // affiche les info du produit
                return View(p);

            }

            // redirige vers la page de depart
            return RedirectToAction("Index");
            
        }
        
      }

}
