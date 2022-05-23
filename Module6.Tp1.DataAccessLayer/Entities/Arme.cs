namespace Module6.Tp1.DataAccessLayer.Entities
{
    using Module6.Tp1.DataAccessLayer.Entities.Abstractions;

    public class Arme : ADataObject
    { 
        public string Nom { get; set; }
        public int Degats { get; set; }
    }
}