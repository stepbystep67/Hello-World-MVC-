using HelloWorld.Models; // 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; // tout ce qui est asp et web
using System.IO;// permet dacceder au system de fichier 
using System.Web.Helpers;// pour utiliser webimage


namespace HelloWorld.Controllers
{
    

    public class ProductController : Controller
    {

        // 
        Dal dal;

        public ProductController()
        {
            // permet de remplacer les elements static par le dynamique (base de donnée = dal)
            dal = new Dal();

        }


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

            // affiche la liste de la base de donnée 
            // en static fallait mettre le nom de la liste a afficher
            return View(dal.GetProducts());

        }


        // routconfig 
        public ActionResult Details(Product _p)
        {

            //  la methode firstordefaut evite de trycatch
            // si il trouve pas de correspondance renvoi null
            Product p = List_Product.FirstOrDefault(x => (x.Reference == _p.Reference));

            // on s'assure que le type est le bon 
            if(p != default(Product))
            {

                // affiche les info du produit
                return View(dal.GetProduct(p.Reference));                                                                                                  // dal.GetProduct();

            }

            // sinon redirige vers la page de depart
            return RedirectToAction("Index");
            
        }

        // affichage puis validation 
        public ActionResult Edit(string id)// reagi avec get mais pas post
        {

            // Product exist = List_Product.FirstOrDefault(x => x.Reference == id);

            Product exist = dal.GetProduct(id);

            if (exist != default(Product))
            {

                // sauf pour modifier creer et supprimer sinon dabord faire la modif puis renvoyer le produit
                dal.UpDateProduct(exist);

                // renvoie le produit 
                return View(exist);                                                                                            // dal.UpDateProduct(id)

            }

            // reaffiche la liste dorigine
            return RedirectToAction("index");

        }

        // validation 
        [AcceptVerbs(HttpVerbs.Post)]//attribut de methode et reagira comme type post mais pas get
        public ActionResult Edit(Product p)
        {

            // Product exist = List_Product.FirstOrDefault(x => x.Reference == p.Reference);
            Product exist = dal.GetProduct(p.Reference);

            if (exist != default(Product))
            {

                exist.ProductName = p.ProductName;
                exist.ProductPrice = p.ProductPrice;
                exist.ProductDescription = p.ProductDescription;
                dal.UpDateProduct(exist);
                
                // request se rempli automatiquement par les methodes post ou get
                // verifier si il y en a au moin un 
                if(Request.Files.Count > 0)
                {

                    // recupere l'image dans file
                    // var s'adapte au type selon le contexte (type dynamique)
                    // recupere le premier element 
                    // files est une collection de fichier, verifier si il y en a au moin un element 
                    HttpPostedFileBase file = Request.Files[0];// permet de prendre le premier 

                    // verifier si il est a null et sa longueur  (si il est valide) 
                    if (file != null && file.ContentLength > 0)
                    {

                        string path = Server.MapPath("/");

                        string path_img = Path.Combine(path, exist.GetImagesPath());

                        string path_th = Path.Combine(path, exist.GetThumbnailPath());

                        file.SaveAs(path_img);

                        //// creation de la variable,avec  qui son "nom" et son "extension" : par la concatenation  
                        //var filename = exist.Reference + ".jpg" ;// remplace l'image par la nouvelle

                        //// recupere le chemin du server , dynamiquement seulement en asp 
                        //string path = Server.MapPath("~/Content/product/");

                        //// chemin complet du fichier combine est une methode qui concatene 
                        //path = Path.Combine(path,filename);
                        
                        WebImage img = new WebImage(file.InputStream);//creation de l'image temporaire 

                        img.Resize(height: 180, width: 320);// redimension de l'image 

                        img.Save(path_th); // enregistre l'image dans le path_th

                    }

                }

            }

            return RedirectToAction("Index");

        }

        // pour l'affichage
        public ActionResult Create()
        {


            return View();
        }

        // 
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Product p)
        {


            if (!ModelState.IsValid)
            {


                return View("Create", p);                                                                     // dal.AddProduct(p)
            }

            //   List_Product.Add(p);

            dal.AddProduct(p);
            
            // rediriger vers une autre page pour ne pas que l'utilisateur puisse actualiser
            return RedirectToAction("index");

        }


        public ActionResult Delete(string id)
        {


            // Product exist = List_Product.FirstOrDefault(x => x.Reference == id);

            Product exist = dal.GetProduct(id);

            if (exist != default(Product))
            {

                return View(exist);                                                                           // dal.DeleteProduct(int id)

            }

            return RedirectToAction("index");
        }

        [HttpPost, ActionName("Delete")]// permet l'utilisation de
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {

            //  Product exist = List_Product.FirstOrDefault(x => x.Reference == id);

            Product exist = dal.GetProduct(id);

            if (exist != default(Product))
            {

                //  if (List_Product.Remove(exist))
                dal.DeleteProduct(exist.Id);
                
            }
            return RedirectToAction("index");

        }


    }

}
