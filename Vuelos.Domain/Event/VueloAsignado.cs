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
        public Guid IdVuelo { get; }
        public Guid IdTripulacion { get; }
        public Guid IdAeronave { get; }

        public VueloAsignado(Guid idVuelo, Guid idTripulacion, Guid idAeronave) : base(DateTime.Now)
        {
            IdVuelo = idVuelo;
            IdTripulacion = idTripulacion;
            IdAeronave = idAeronave;
        }
    }
}
