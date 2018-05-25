using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;// gerer les donnees et annotation de données (accepte les attribut de methode stringlength,required,display...


// toujours en public pour le framework et controller puisse le remplir  !!!!!!!
namespace HelloWorld.Models
{

    public class Product
    {

        // les modelstate (attribut de methode) sert a ne pas faire des conditions if et autres !!!
        // nouvelle syntaxe pour les accesseur

        // soit le formulair s'est valider soit ce message d'erreur 
        [StringLength(8,ErrorMessage ="la reference est trop longue ")]// defini la longueur maximal de la reference (propriete doit faire 8 pas plus )
        [Required(ErrorMessage= "La réference est requise")]// annotation (gere le cas ou le texte n'est pas entrer !!)
        [Display(Name ="reference produit")]// change le texte qui est a la base le nom de la propriete !(au lieu du nom du champ le texte defini )
        public string Reference
        {

           get;
           set;

        }

        // si il y a une erreur alors se sera celui ci
        [Required(ErrorMessage ="La réference est requise")]
        [StringLength(8, ErrorMessage = "la reference est trop longue ")]
        [Display(Name = "reference produit")]// change le texte qui est a la base le nom de la propriete
        public string ProductDescription
        {

             get;
             set;

        }

        // si il y a une erreur alors se sera celui ci
        [Display(Name = "reference produit")]// change le texte qui est a la base le nom de la propriete
        public string ProductName
        {

             get;
             set;

        }

        // si il y a une erreur alors se sera celui ci
        [Required(ErrorMessage ="La réference est requise")]
        [Display(Name = "prix toutes taxes comprises")]// change le texte qui est a la base le nom de la propriete
        public double ProductPrice
        {

            get;
             set;

        }


        // constructeur par defaut
        public Product()
        {



        }

        // constructeur avec parametre ref equivalent id pour identifier
        public Product(string _ref)
        {

            // this correspond a celui de la class et sans sera celui du constructeur 
            this.Reference = _ref;

        }

        public string GetImage()
        {

            // permet de trouver et afficher la bonne image du produit choisi par l'utilisateur 
            return "Content/product/" + Reference + ".jpg";
        }


        public string GetThumbnail()
        {



            return "Content/product/" + Reference + "_th.jpg";
        }

    }
}
