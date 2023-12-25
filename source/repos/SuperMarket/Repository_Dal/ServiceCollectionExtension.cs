using Microsoft.Extensions.DependencyInjection;
using Repository_Dal.Interfaces;
using Repository_Dal.Models;
using Repository_Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository_Dal.Repositories
{
    public static class ServiceCollectionExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Product>, ProductRepository>();
        }
    }
}
