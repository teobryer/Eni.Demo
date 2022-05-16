using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eni.Demo.Module2
{
   public class Point
    {

        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }


        public void Ajouter(Point p)
        {
            this.X += p.X;
            Y += p.Y;
        }


    }
}
