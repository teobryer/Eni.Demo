using Eni.TP_Pizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eni.TP_Pizza.Profile

{
    public class BusinessProfile : AutoMapper.Profile
    {
        public BusinessProfile()
        {
            this.CreateMap<Pizza, Pizza>();

           
        }
    }
}

