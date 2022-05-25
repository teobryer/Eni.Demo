using Module6.Tp1.DataAccessLayer.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module6.Tp1.DataAccessLayer.Entities
{
    public class ArtMartial : ADataObject
    {

        public string Nom { get; set; }

        [InverseProperty("ArtsMartiaux")]
        public virtual List<Samourai> Samourais { get; set; } = new();
}
}
