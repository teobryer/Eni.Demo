namespace Module6.Tp1.Web.Business.DataProviders.Dtos
{
    public class SamouraiDto
    {
        public int Id { get; set; }
        public int Force { get; set; }
        public string Nom { get; set; }
        public int? ArmeId { get; set; }

        public string ArmeNom { get; set; }
        public virtual ArmeDto Arme { get; set; }
    }
}
