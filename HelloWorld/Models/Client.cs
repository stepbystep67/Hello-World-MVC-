using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// creation des modeles
namespace HelloWorld.Models
{

    public class Client
    { 
        
        // declaration indispensable pour le constructeur
        private string nom;
        private string prenom;
        private int id;

        public Client()
        {



        }

        // constructeur avec deux parametres 
        public Client(int _id,string _nom, string _prenom)
        {

            // mettre les parametres dans les variables qui seront utilisable partout grace aux accesseurs
            this.Nom = _nom;
            this.Prenom = _prenom;
            this.id = _id;

        }

        // accesseur de propriété nom
        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        // accesseur de propriété prenom
        public string Prenom
        {
            get
            {
                return prenom;
            }

            set
            {
                prenom = value;
            }
        }

        // accesseur de propriete id
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
    }

}
