using Domotics.DataAccessLayer.AccessLayers;
using Domotics.DataAccessLayer.AccessLayers.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domotics.DataAccessLayer
{
   public static class ServiceExtension
    {

        public static IServiceCollection AddDalServices(this IServiceCollection services)
        {
            services.AddDbContext<DomoticsContext>();

            services.AddTransient<IMeasureAccessLayer, MeasureAccessLayer>();
       
            
            return services;
        }
    }
}
