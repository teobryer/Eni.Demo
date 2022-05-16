using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eni.Demo.Module2
{
    public class Personne
    {

        // atributs privés

        private string nom;
        private string prenom;
        private int age;




        // Propriétés:

        public int Age   // property
        {
            get { return age; }   // get method
            set { age = value; }  // set method
        }

        public string Prenom   // property
        {
            get { return prenom; }   // get method
            set { prenom = value; }  // set method
        }

        public string Nom   // property
        {
            get { return nom; }   // get method
            set { nom = value; }  // set method
        }



        public Personne(string prenom, string nom, int age)
        {
            this.prenom = prenom;
            this.nom = nom;
            this.age = age;
        }

    }


}
