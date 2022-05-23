namespace Module6.Tp1.Web.Business
{
    using Microsoft.Extensions.DependencyInjection;
    using Module6.Tp1.Web.Business.DataProviders;
    using Module6.Tp1.Web.Business.DataProviders.Abstractions;
    using Module6.Tp1.DataAccessLayer;

    public static class BusinessExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddDalServices();

            services.AddTransient<IArmeService, ArmeService>();
            services.AddTransient<ISamouraiService, SamouraiService>();
            return services;
        }
    }
}
