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

       // [InverseProperty("Arme")]
        public virtual  List<Samourai> Samourais { get; set; }

        
    }
}