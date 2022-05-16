using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Heritage.BO
{
    public class Rectangle : Forme
    {
        public int Largeur { get; set; }
        public int Longueur { get; set; }

        public override string ToString()
        {



            var cote = new Func<int, int, String>((longu, larg) =>
            {

                return $"Rectangle de longueur = {longu} , largeur = {larg} \n";
            });




            var aire = new Func<int, int, String>((longu, larg) =>
            {

                return $"Aire = {longu * larg} \n";
            });


            var perimetre = new Func<int,int, String>((longu, larg) =>
            {

                return $"Perimetre  = {longu * 2 + larg * 2} \n";
            });
            return cote(this.Longueur, this.Largeur) + aire(this.Longueur, this.Largeur) + perimetre(this.Longueur, this.Largeur);
        }
    }
}
