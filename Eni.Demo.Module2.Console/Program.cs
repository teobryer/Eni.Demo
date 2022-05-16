using Eni.Demo.Module2.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eni.Demo.Module2.Console
{
    using System;
    class Program

    {


        static void Main(string[] args)
        {

           
        }


        private static void Demo01()
        {
            var pointA = new Point(1, 1);


            Console.WriteLine(pointA.X + ";" + pointA.Y);

            pointA.Ajouter(new Point(2, 2));


            Console.WriteLine(pointA.X + ";" + pointA.Y);
            Console.ReadLine();
        }
    }
}
