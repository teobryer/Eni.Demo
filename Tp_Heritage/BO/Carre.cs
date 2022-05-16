using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Heritage.BO
{
    public class Carre : Forme
    {
        public int Longueur { get; set; }

        public override string ToString()
        {



            var cote = new Func<int, String>(longu =>
            {

                return $"Carre de coté {longu} \n";
            });




            var aire = new Func<int, String>((longu) =>
            {

                return $"Aire = {longu * longu} \n";
            });


            var perimetre = new Func<int, String>((longu) =>
            {

                return $"Perimetre  = {longu * 4} \n";
            });
            return cote(this.Longueur) + aire(this.Longueur) + perimetre(this.Longueur);
        }
    }
}
