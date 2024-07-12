using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            // builder.Services.AddPersistenceServices();
            services.AddDbContext<BorusanDbContext>();
            services.AddScoped<IBrandRepository, EfBrandRepository>();

            return services;
        }
    }
}
