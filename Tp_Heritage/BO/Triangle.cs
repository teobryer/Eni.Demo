using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Heritage.BO
{
    public class Triangle : Forme
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public override string ToString()
        {



            var cote = new Func<int,int, int, String>((a,b,c) =>
            {

                return $"Triangle de coté A = {a}, B = {b}, C = {c} \n";
            });




        


            var perimetre = new Func<int, int, int, String>((a,b,c) =>
            {

                return $"Perimetre  = {a+b+c } \n";
            });

            var perimetreDivide2 = new Func<int, int, int, double>((a, b, c) =>
            {

                return (a + b + c) /2.0 ;
            });


            var aire = new Func<int, int, int, double, String>((a, b, c, per) =>
            {

                return $"Aire = {Math.Sqrt(per * (per - a)* (per - b) * (per - c))} \n";
            });


            return cote(A,B,C) + aire(this.A, this.B, this.C,(perimetreDivide2(A,B,C)) ) + perimetre(A,B,C);
        }
    }
}
