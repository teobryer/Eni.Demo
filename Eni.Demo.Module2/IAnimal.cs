namespace Module2
{
    public interface IAnimal<T> where T : INourriture
    {
        bool SeNourrir(T aliment);
    }
}
