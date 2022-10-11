using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Application.Services;
using Vuelos.Domain.Factories;

namespace Vuelos.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IVueloService, VueloService>();
            services.AddTransient<IVueloFactory, VueloFactory>();

            services.AddTransient<IAeropuertoFactory, AeropuertoFactory>();

            return services;
        }
    }
}
