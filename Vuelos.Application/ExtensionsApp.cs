using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shared.Rabbitmq.BusRabbit;
using Shared.Rabbitmq.EventoQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Application.UseCases.ManejadorRabbit;

namespace Vuelos.Application
{
    public static class ExtensionsApp
    {
        public static IApplicationBuilder RabbitMQConsumer(this IApplicationBuilder app)
        {

            ///<Sumary>
            ///registrar el evento Queue del bus
            ///Para el CONSUMIDOR (Subscriber) al evento ejemplo EmailEventoQueue que esta en el bus
            ///<Sumary>
            var eventBus1 = app.ApplicationServices.GetRequiredService<IRabbitEventBus>();
            eventBus1.Subscribe<TripulacionEventoQueue, TripulacionCreadaEventoManejador>();
            var eventBus2 = app.ApplicationServices.GetRequiredService<IRabbitEventBus>();
            eventBus2.Subscribe<AeronaveAgregadaEventoQueue, AeronaveAgregadaEventoManejador>();
            var eventBus3 = app.ApplicationServices.GetRequiredService<IRabbitEventBus>();
            eventBus3.Subscribe<AeropuertoCreadoQueue, AeropuertoCreadoEventoManejador>();

            return app;
        }
    }
}
