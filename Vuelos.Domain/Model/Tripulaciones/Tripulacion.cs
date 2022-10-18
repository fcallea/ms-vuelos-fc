using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Domain.Model.Tripulaciones
{
    public class Tripulacion : AggregateRoot<Guid>
    {
        public string EstadoTripulacion { get; set; }
        private Tripulacion() { }

        internal Tripulacion(Guid id, string estadoTripulacion)
        {
            Id = id;
            EstadoTripulacion = estadoTripulacion;
        }
        /*
        public void ConsolidarTripulacion()
        {
            var evento = new TripulacionRegistrada(Id);
            AddDomainEvent(evento);
        }
        */
    }
}
