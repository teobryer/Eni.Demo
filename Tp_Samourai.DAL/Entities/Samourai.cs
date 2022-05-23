namespace Tp_Samourai.DAL.Entities
{
    public class Samourai : IEntity
    {
        public int Id { get; set; }
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }

        public override int getId()
        {
            return Id;
        }
    }
}
