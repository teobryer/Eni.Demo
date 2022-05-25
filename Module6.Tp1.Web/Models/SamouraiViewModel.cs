using AutoMapper;
using Module6.Tp1.Web.Business.DataProviders.Dtos;
using System.Collections.Generic;

namespace Module6.Tp1.Web.Models
{
    public class SamouraiViewModel
    {

       
        public int Id { get; set; }
        public int Force { get; set; }
        public string Nom { get; set; }
        public int ArmeId { get; set; }
        public string ArmeNom { get; set; }

        public List<int> ListeArtsMartiauxId { get; set; }
        public List<string> ListeArtsMartiauxNom { get; set; }



    }



}
