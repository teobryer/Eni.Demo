using System.Collections.Generic;

namespace Module6.Tp1.Web.Business.DataProviders.Dtos
{
    public class SamouraiDto
    {
        public int Id { get; set; }
        public int Force { get; set; }
        public string Nom { get; set; }
        public int? ArmeId { get; set; }

        public List<int> ListeArtsMartiauxId { get; set; } = new();

        public virtual List<ArtMartialDto> ArtsMartiaux { get; set; } = new();

        public string ArmeNom { get; set; }
        public virtual ArmeDto Arme { get; set; }
    }
}
