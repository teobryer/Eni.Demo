using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Heritage.BO
{
    public class Cercle : Forme
    {
        public int Rayon { get; set; }

        public override string ToString()
        {



            var rayon = new Func<int, String>(r =>
            {

                return $"Cercle de rayon = {r} \n";
            });




            var perimetre = new Func<int, double, String>((r, pi) =>
             {

                 return $"Perimetre = {2 * pi * r} \n";
             });


            var aire = new Func<int, double, String>((r, pi) =>
             {

                 return $"Aire  = {pi * r * r} \n";
             });
            return rayon(this.Rayon) + aire(this.Rayon, Math.PI) + perimetre(this.Rayon, Math.PI);
        }
    }
}
