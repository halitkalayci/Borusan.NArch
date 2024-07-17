using Application.Encryption.JWT;
using Application.Features.Brands.Commands.Create;
using Application.Pipeline.Auth;
using Application.Pipeline.Example;
using Application.Pipeline.Logging;
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
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, TokenOptions tokenOptions)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
                // SIRA ÖNEMLİ!
                configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
                configuration.AddOpenBehavior(typeof(AuthBehavior<,>));
                configuration.AddOpenBehavior(typeof(ExampleBehavior<,>));
                // 
            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ITokenHelper, JwtHelper>(_ => new JwtHelper(tokenOptions));
            return services;
        }
    }
}
