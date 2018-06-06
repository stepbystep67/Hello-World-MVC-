using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;// permet la creation de persistance de données

// https://openclassrooms.com/courses/apprendre-asp-net-mvc/le-modele-36

namespace HelloWorld.Models
{

    // https://msdn.microsoft.com/fr-fr/library/system.data.entity.dbcontext(v=vs.113).aspx
    // Une instance DbContext représente une combinaison de modèles d'unité de travail et de référentiel pouvant être utilisée pour interroger une base de données et un groupe simultanément de sorte que les modifications seront ensuite réécrites sur le magasin sous la forme d'une unité. DbContext est conceptuellement semblable à ObjectContext.
    // bddcontext herite de DbContext ! permet dacceder sans requete sql
    public class BddContext : DbContext// ajouter a partir du double point 
    {

        public DbSet<Client> Clients { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }

        // https://msdn.microsoft.com/en-us/library/system.data.entity.dbcontext.onmodelcreating(v=vs.113).aspx
        // Cette méthode est appelée lorsque le modèle d'un contexte dérivé a été initialisé, mais avant que le modèle ait été verrouillé et utilisé pour initialiser le contexte. L'implémentation par défaut de cette méthode ne fait rien, mais elle peut être surchargée dans une classe dérivée de telle sorte que le modèle puisse être configuré avant d'être verrouillé.
        // This method is called when the model for a derived context has been initialized, but before the model has been locked down and used to initialize the context. The default implementation of this method does nothing, but it can be overridden in a derived class such that the model can be further configured before it is locked down.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BddContext>()); // creer la base de donnée si le model change et on precise la classe d'initialisation http://www.entityframeworktutorial.net/code-first/database-initialization-strategy-in-code-first.aspx
            base.OnModelCreating(modelBuilder);

        }

    }

}
