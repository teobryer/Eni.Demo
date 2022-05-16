using System;
namespace Module2
{
    class Fourmi : IAnimal<Fruit>
    {
        public bool SeNourrir(Fruit aliment)
        {
            if (aliment.EstPerime())
                return false;

            Console.WriteLine("Crunch crunch, la fourmi mange un fruit");
            return true;
        }
    }
}
