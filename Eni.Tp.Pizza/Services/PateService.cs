using Eni.TP_Pizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eni.TP_Pizza.Services
{
    public class PateService : IPateService
    {
        public List<Pate> recupererListePates()
        {
            return Pizza.PatesDisponibles;
        }
    }
}
