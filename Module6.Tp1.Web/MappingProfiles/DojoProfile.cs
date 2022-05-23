using AutoMapper;
using Module6.Tp1.Web.Business.DataProviders.Dtos;
using Module6.Tp1.Web.Models;

namespace Module6.Tp1.Web.MappingProfiles
{
    public class DojoProfile : Profile
    {
        public DojoProfile()
        {
            _ = this.CreateMap<ArmeDto, ArmeViewModel>()
                .ReverseMap();

            _ = this.CreateMap<SamouraiDto, SamouraiViewModel>()
               .ReverseMap();
        }
    }
}
