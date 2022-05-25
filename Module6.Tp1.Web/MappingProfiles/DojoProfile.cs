using AutoMapper;
using Module6.Tp1.Web.Business.DataProviders.Dtos;
using Module6.Tp1.Web.Models;
using System.Linq;

namespace Module6.Tp1.Web.MappingProfiles
{
    public class DojoProfile : Profile
    {
        public DojoProfile()
        {
            _ = this.CreateMap<ArmeDto, ArmeViewModel>()
                .ReverseMap();

            _ = this.CreateMap<SamouraiDto, SamouraiViewModel>()
                .ForMember(dest => dest.ListeArtsMartiauxId, opt => opt.MapFrom(src => src.ListeArtsMartiauxId))
                .ForMember(dest => dest.ListeArtsMartiauxNom, opt => opt.MapFrom(src => src.ArtsMartiaux.Select(x => x.Nom)))
               .ReverseMap();

            _ = this.CreateMap<ArtMartialDto, ArtMartialViewModel>()
               .ReverseMap();
        }
    }
}
