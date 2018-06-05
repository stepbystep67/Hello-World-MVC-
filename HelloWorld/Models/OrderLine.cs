using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; // utilisation d'entité 
using System.IO;
using System.ComponentModel.DataAnnotations;   // permet d'utiliser les attributs de propriete



namespace HelloWorld.Models
{
    
    public class OrderLine
    {

        // accesseur nouvelle syntaxe
        
        private int Id { get; set; }


        private int IdOrder { get; set; }


        private int IdProduct { get; set; }

        [Display(Name ="Quantité")]
        private int Quantity { get; set; }

        [Display(Name ="Prix")]
        private double Price { get; set; }

        public OrderLine()
        {


            return;
        }

        public OrderLine(int Quantity,double Price)
        {


            return;
        }


    }

}