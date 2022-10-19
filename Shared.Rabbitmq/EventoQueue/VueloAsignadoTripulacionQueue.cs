using Shared.Rabbitmq.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Rabbitmq.EventoQueue
{
    public class VueloAsignadoTripulacionQueue : Evento
    {
        public Guid VueloGuid { get; set; }
        public Guid TripulacionGuid { get; set; }
        public Guid Id { get; set; } //AeronaveGuid

    public VueloAsignadoTripulacionQueue(Guid vueloGuid, Guid tripulacionGuid, Guid aeronaveGuid)
        {
            VueloGuid = vueloGuid;
            TripulacionGuid = tripulacionGuid;
            Id = aeronaveGuid;
        }
    }
}
