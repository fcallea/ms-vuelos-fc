using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Domain.Event
{
    public record VueloAsignado : DomainEvent
    {
        public Guid IdItinerarioVuelo { get; }
        public Guid IdTripulacion { get; }
        public Guid IdAeronave { get; }

        public VueloAsignado(Guid idItinerarioVuelo, Guid idTripulacion, Guid idAeronave) : base(DateTime.Now)
        {
            IdItinerarioVuelo = idItinerarioVuelo;
            IdTripulacion = idTripulacion;
            IdAeronave = idAeronave;
        }
    }
}
