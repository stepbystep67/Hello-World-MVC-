using System.ComponentModel.DataAnnotations;   // permet d'utiliser les attributs de propriete ici display au dessus de nos accesseurs

namespace HelloWorld.Models
{

    public class OrderLine
    {

        public int Id { get; set; }

        // attribut de propriete 
        [Display(Name ="identifiant de la commande")]
        public int IdOrder { get; set; }

       
        [Display(Name ="identifiant du produit")]
        public int IdProduct { get; set; }

       
        [Required(ErrorMessage ="veuillez indiquer la quantité s'il vous plait")]
        [Display(Name ="Quantité")]
        public int Quantity { get; set; }
        

        [Required(ErrorMessage ="veuillez indiquer le prix s'il vous plait")]
        [Display(Name ="Prix")]
        public double Price { get; set; }


        public OrderLine()
        {


            return;
        }


    }

}
