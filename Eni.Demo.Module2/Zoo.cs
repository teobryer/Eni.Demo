namespace Module2
{
    public static class Zoo
    {
        public static bool NourrirAnimal<A, N>(A animal, N aliment)
            where N : INourriture
            where A : IAnimal<N>
        {
            return animal.SeNourrir(aliment);
        }
    }
}
