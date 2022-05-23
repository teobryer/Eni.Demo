using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp_Samourai.DAL.Entities;

namespace Tp_Samourai.DAL
{
    public static class AddDALService
    {

        public static IServiceCollection AddDbContextDal(this IServiceCollection collection)
        {
            collection.AddDbContext<SamouraiDbContext>();
            collection.AddTransient<AccesLayer<Arme>>();
            collection.AddTransient<AccesLayer<Samourai>>();

            return collection;
        }
    }
}
