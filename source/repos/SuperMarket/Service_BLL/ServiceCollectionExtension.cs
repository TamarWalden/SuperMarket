using Microsoft.Extensions.DependencyInjection;
using Repository_Dal;
using Repository_Dal.Models;
using Repository_Dal.Repositories;
using Service_BLL;
using Service_BLL.Interfaces;
using Service_BLL.Services;

namespace Services
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddScoped<IProductService, ProductService>();
            services.AddSingleton<IContext, SuperMarketContext>();
            services.AddAutoMapper(typeof(Mapper));
        }
    }
}