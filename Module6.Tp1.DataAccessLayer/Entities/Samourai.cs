namespace Module6.Tp1.DataAccessLayer.Entities
{
    using Module6.Tp1.DataAccessLayer.Entities.Abstractions;
    using System;

    public class Samourai : ADataObject
    {
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }
        public int? ArmeId { get; set; }

      
    }
}
