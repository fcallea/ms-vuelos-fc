using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shared.Rabbitmq.BusRabbit;
using Shared.Rabbitmq.Implement;
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

            AddRabbitMq(services);

            return services;
        }


        private static void AddRabbitMq(this IServiceCollection services)
        {
            ///<Sumary>
            ///Se agrega el bus de RabbitMQ, sera utiliza para cualquier microservicio.
            ///Para el PRODUCTOR (Publisher) y tambien para el CONSUMIDOR
            ///<Sumary>
            services.AddTransient<IRabbitEventBus, RabbitEventBus>();

            ///<Sumary>
            ///Se agrega el eventomanejador de RabbitMQ.
            ///Para el CONSUMIDOR (Subscriber), implementacion de evento manejador
            ///<Sumary>
            //services.AddTransient<IEventoManejador<VueloAsignadoAeronaveQueue>, AeronaveEventoManejador>();

        }
    }
}
