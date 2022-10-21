using Shared.Rabbitmq.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Rabbitmq.EventoQueue
{
    public class VueloAsignadoReservaQueue : Evento
    {
        public Guid Id { get; set; }
        public Guid TripulacionGuid { get; set; }
        public Guid AeronaveGuId { get; set; } //AeronaveGuid
        public string Detalle { get; set; }
        public int Cantidad { get; set; }

        public VueloAsignadoReservaQueue(Guid id, Guid tripulacionGuid, Guid aeronaveGuid, string detalle, int cantidad)
        {
            Id = id;
            TripulacionGuid = tripulacionGuid;
            AeronaveGuId = aeronaveGuid;
            Detalle = detalle;
            Cantidad = cantidad;
        }
    }
}
