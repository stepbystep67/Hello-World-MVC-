using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Models
{

    public class Product
    {

        // nouvel syntaxe pour accesseur
        public string Reference
        {

           get;
           set;

        }


       public string ProductDescription
        {

            get;
             set;

        }


        public string ProductName
        {

            get;
             set;

        }


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


    }
}