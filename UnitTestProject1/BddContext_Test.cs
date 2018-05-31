using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld.Models; // permet l'acces au contenu de l'autre projet
using System.Collections.Generic;


namespace UnitTestProject1
{

    [TestClass]
    public class BddContext_Test
    {

        // attribut de methode test !
        [TestMethod] // Permet d'identifier des méthodes de test.  Cette classe ne peut pas être héritée.   https://msdn.microsoft.com/fr-fr/library/microsoft.visualstudio.testtools.unittesting.testmethodattribute.aspx
        public void TestMethod1()
        {

            // creer une variable temporaire disponible que dans le using, methode dispose  
            using (Dal dal = new Dal())
            {

                // acces base de donnée + methode + instanciation d'un nouveau produit avec ses proprieté completées
                dal.AddProduct(new Product { Reference = "gp20", ProductName = "google play", ProductDescription = "application", ProductPrice = 1 });

                // instanciation d'une liste de produit ou l'on y mets le resultat de la méthode qui retourne une liste
                List<Product> products = dal.GetProduct();

                Assert.IsNotNull(products);// compare si il est nul 
                // assert.areequal(1,productname.count) compare les deux
                Assert.AreEqual("gp20",products[0].Reference);

                Assert.AreEqual("google play",products[0].ProductName);
                
            }

        }

        // attribut de methode test !
        [TestMethod] // Permet d'identifier des méthodes de test.  Cette classe ne peut pas être héritée.   https://msdn.microsoft.com/fr-fr/library/microsoft.visualstudio.testtools.unittesting.testmethodattribute.aspx
        public void TestMethod2()
        {

            using (Dal dal = new Dal())
            {

                dal.AddClient(new Client {  Prenom = "Justin", Nom = "Alemany" });

                List<Client> client = dal.GetClient();

                Assert.IsNotNull(client);

                Assert.AreEqual("Alemany",client[0].Nom);

                Assert.AreEqual("Justin", client[0].Prenom);
                
            }

        }

    }

}
