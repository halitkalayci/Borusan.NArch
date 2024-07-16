using Application.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
                configuration.AddOpenBehavior(typeof(ExampleBehavior<,>));
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
