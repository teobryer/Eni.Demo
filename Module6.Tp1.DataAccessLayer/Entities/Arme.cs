namespace Module6.Tp1.DataAccessLayer.Entities
{
    using Module6.Tp1.DataAccessLayer.Entities.Abstractions;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Arme : ADataObject
    { 
        public string Nom { get; set; }
        public int Degats { get; set; }

        public int? SamouraiId { get; set; }
        public virtual  Samourai Samourai { get; set; }

        
    }
}