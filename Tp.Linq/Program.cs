using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp.Linq.BO;

namespace Tp.Linq
{
    class Program
    {



        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }

        static void Main(string[] args)
        {


            InitialiserDatas();





            Console.WriteLine("Liste des prénoms des auteurs dont le nom commence par G : ");
            ListeAuteurs.Select(a => a.Nom).Where(nom => nom.First() == 'G').ToList().ForEach(i => Console.Write("{0}\t", i));
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Afficher l’auteur ayant écrit le plus de livres : ");
            Console.WriteLine(ListeLivres.GroupBy(x => x.Auteur).OrderByDescending(x => x.Count()).First().Key);
            Console.WriteLine(Environment.NewLine);



            Console.WriteLine("Afficher le nombre moyen de pages par livre par auteur : ");
            ListeLivres.GroupBy(x => x.Auteur).Select(g => new { MoyennePage = g.Average(p => p.NbPages), Auteur = g.Key }).ToList().ForEach(i => Console.Write("{0}\t", i));
            Console.WriteLine(Environment.NewLine);


            Console.WriteLine("Afficher le titre du livre avec le plus de pages : ");
            Console.WriteLine(ListeLivres.Where(li => li.NbPages == ListeLivres.Max(l => l.NbPages)).First());
            Console.WriteLine(Environment.NewLine);


            Console.WriteLine("Afficher combien ont gagné les auteurs en moyenne(moyenne des factures) : ");
            ListeAuteurs.Select(x => new { MoyenneFacture = x.Factures.Count > 0 ? x.Factures.Average(f => f.Montant) : 0, Auteur = x }).ToList().ForEach(i => Console.Write("{0}\t", i));
            Console.WriteLine(Environment.NewLine);


            Console.WriteLine("Afficher les auteurs et la liste de leurs livres");
            ListeAuteurs.Select(a => new { Auteur = a, Livres = ListeLivres.Where(l => l.Auteur == a) }).ToList().ForEach(i => { if (i.Livres.Any()) Console.Write("{0} a écrit les livres {1}\t", i.Auteur, i.Livres.Select(l => l.ToString()).Aggregate((x, y) => x.ToString() + "," + y.ToString())); else Console.Write("{0} n'a pas écrit de livres\t", i.Auteur); Console.WriteLine(Environment.NewLine); });
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Afficher les titres de tous les livres triés par ordre alphabétique : ");
            ListeLivres.OrderBy(l=> l.Titre).ToList().ForEach(i => Console.Write("{0}\t" + Environment.NewLine, i) );
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Afficher la liste des livres dont le nombre de pagesest supérieurà la moyenne :");
            ListeLivres.Where(l => l.NbPages > ListeLivres.Average(x => x.NbPages)).ToList().ForEach(i => Console.Write("{0}\t" + Environment.NewLine, i)); 
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Afficher l'auteur ayant écrit le moins de livres :");
            Console.WriteLine(ListeLivres.GroupBy(x => x.Auteur).OrderByDescending(x => x.Count()).Last().Key);
            Console.WriteLine(Environment.NewLine);





            Console.ReadKey();
        }
    }
}
