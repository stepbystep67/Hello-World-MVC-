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
        [Display(Name ="identifiant unique")]
        private int Id { get; set; }

       
        [Display(Name ="identifiant de la commande")]
        private int IdOrder { get; set; }

       
        [Display(Name ="identifiant du produit")]
        private int IdProduct { get; set; }

       
        [Required(ErrorMessage ="veuillez indiquer la quantité s'il vous plait")]
        [Display(Name ="Quantité")]
        private int Quantity { get; set; }
        

        [StringLength(8,ErrorMessage ="le prix est trop long 8max")]
        [Required(ErrorMessage ="veuillez indiquer le prix s'il vous plait")]
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
