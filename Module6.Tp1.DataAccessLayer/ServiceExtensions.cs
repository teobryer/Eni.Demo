using Microsoft.Extensions.DependencyInjection;
using Module6.Tp1.DataAccessLayer.AccessLayers;
using Module6.Tp1.DataAccessLayer.AccessLayers.Abstractions;

namespace Module6.Tp1.DataAccessLayer
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDalServices(this IServiceCollection services)
        {
            services.AddDbContext<DojoContext>();

            services.AddTransient<IArmeAccessLayer, ArmeAccessLayer>();
            services.AddTransient<ISamouraiAccessLayer, SamouraiAccessLayer>();

            return services;
        }
    }
}
