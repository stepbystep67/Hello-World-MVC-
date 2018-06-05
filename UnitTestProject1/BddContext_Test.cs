using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld.Models; // permet l'acces au contenu de l'autre projet
using System.Collections.Generic;


namespace UnitTestProject1
{

    [TestClass] // L’attribut [TestClass] désigne une classe qui contient des tests unitaires
    public class BddContext_Test
    {
        
        // attribut de methode test !
        [TestMethod]// Cette classe ne peut pas être héritée. L’attribut [TestMethod] indique une méthode qui est une méthode de test.  https://msdn.microsoft.com/fr-fr/library/microsoft.visualstudio.testtools.unittesting.testmethodattribute.aspx
        public void TestMethod1()
        {

            // creer une variable temporaire disponible que dans le using, methode dispose  
            using (Dal dal = new Dal())
            {

                // acces base de donnée + methode + instanciation d'un nouveau produit avec ses proprieté completées
                dal.AddProduct(new Product { Reference = "gp20", ProductName = "google play", ProductDescription = "application", ProductPrice = 1 });

                // instanciation d'une liste de produit ou l'on y mets le resultat de la méthode qui retourne une liste
                List<Product> products = dal.GetProducts();

                Assert.IsNotNull(products);// si il est null ,donc si il y en a au moin un ...
  
                // assert.areequal(1,productname.count) compare les deux
                Assert.AreEqual("gp20",products[0].Reference);

                Assert.AreEqual("google play",products[0].ProductName);//https://openclassrooms.com/courses/programmez-en-oriente-objet-avec-c/les-tests-unitaires-5
                
                 if (products.Count > 0)
                 {

                    
                    
                 }
              
             
            }

        }


        // attribut de methode test !
        [TestMethod] // Permet d'identifier des méthodes de test.  Cette classe ne peut pas être héritée.   https://msdn.microsoft.com/fr-fr/library/microsoft.visualstudio.testtools.unittesting.testmethodattribute.aspx
        public void TestMethod2()
        {

            // creation d'une nouvelle base de donnée que l'on mets dans dal de type data access layer
            using (Dal dal = new Dal())
            {

                // 
                dal.AddClient(new Client {  Prenom = "Justin", Nom = "Alemany" });

                List<Client> client = dal.GetClients();

                Assert.IsNotNull(client);

                Assert.AreEqual("Alemany",client[0].Nom);

                Assert.AreEqual("Justin", client[0].Prenom);
                
            }

        }

        
        [TestMethod]
        public void TestAll() // tous testés
        {
            
            using (Dal dal = new Dal())
            {

                // testmethod = utilisé l'objet assert et ses methodes pour verfirier ou comparer les resultats attendus
                // on ajoute un client 
                dal.AddClient(new Client { Prenom = "philipe", Nom = "moris" });

                // recupere le client par id
                List<Client> ma_liste = dal.GetClients();

                // le client doit etre identique si on veut que ca marche
                Assert.AreEqual(1, ma_liste.Count);


            }


        }


    }

}
