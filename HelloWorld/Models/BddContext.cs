using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;// permet la creation de persistance de données

// https://openclassrooms.com/courses/apprendre-asp-net-mvc/le-modele-36

namespace HelloWorld.Models
{

    // bddcontext herite de DbContext ! permet dacceder sans requete sql
    public class BddContext : DbContext// ajouter a partir du double point 
    {

        public DbSet<Client> Clients { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }
        
        // 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BddContext>()); // creer la base de donnée si le model change et on precise la classe d'initialisation http://www.entityframeworktutorial.net/code-first/database-initialization-strategy-in-code-first.aspx
            base.OnModelCreating(modelBuilder);

        }

    }

}
