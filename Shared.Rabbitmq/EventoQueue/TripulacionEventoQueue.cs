using Shared.Rabbitmq.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Rabbitmq.EventoQueue
{
    public class TripulacionEventoQueue : Evento
    {
        public Guid TripulacionGuid { get; set; }
        public int TripulacionId { get; set; }
        public string TripulacionNombre { get; set; }
        public int TripulacionEstado { get; set; }

        public TripulacionEventoQueue(Guid tripulacionGuid, int tripulacionId, string tripulacionNombre, int tripulacionEstado)
        {
            //TripGuid = tripGuid;
            //TripId = tripId;
            //NombreTripulacion = nombreTripulacion;
            //EstadoTrip = estadoTrip;
            TripulacionGuid = tripulacionGuid;
            TripulacionId = tripulacionId;
            TripulacionNombre = tripulacionNombre;
            TripulacionEstado = tripulacionEstado;
        }
    }
}
