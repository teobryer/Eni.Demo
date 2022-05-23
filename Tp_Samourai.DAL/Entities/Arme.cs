namespace Tp_Samourai.DAL.Entities
{
    public class Arme : IEntity
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Degats { get; set; }

        public override int getId()
        {
            return Id;
        }
    }
}