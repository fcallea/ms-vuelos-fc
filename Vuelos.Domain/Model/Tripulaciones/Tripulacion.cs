using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Domain.Model.Tripulaciones
{
    public class Tripulacion : AggregateRoot<Guid>
    {
        public string EstadoTripulacion { get; set; }
        public string TripulacionNombre { get; set; }

        [ExcludeFromCodeCoverage]
        private Tripulacion() { }

        internal Tripulacion(Guid id, string tripulacionNombre, string estadoTripulacion)
        {
            Id = id;
            TripulacionNombre = tripulacionNombre;
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
