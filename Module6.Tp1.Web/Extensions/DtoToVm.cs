using AutoMapper;
using Module6.Tp1.Web.Business.DataProviders.Dtos;
using Module6.Tp1.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module6.Tp1.Web.Extensions
{
    public static class DtoToVm
    {


        public static SamouraiViewModel ToVM(this SamouraiDto dto, IMapper mapper)
        {
            return mapper.Map<SamouraiViewModel>(dto);
        }

        public static SamouraiDto ToDTO(this SamouraiViewModel vm, IMapper mapper)
        {
            return mapper.Map<SamouraiDto>(vm);
        }


        public static ArmeViewModel ToVM(this ArmeDto dto, IMapper mapper)
        {
            return mapper.Map<ArmeViewModel>(dto);
        }

        public static ArmeDto ToDTO(this ArmeViewModel vm, IMapper mapper)
        {
            return mapper.Map<ArmeDto>(vm);
        }


    }
}
