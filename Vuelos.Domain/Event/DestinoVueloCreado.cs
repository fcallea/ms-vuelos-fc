using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Domain.Event
{
    public record DestinoVueloCreado : DomainEvent
    {
        public Guid IdVuelo { get; }
        public Guid IdAeropuertoOrigen { get; }
        public Guid IdAeropuertoDestino { get; }

        public DestinoVueloCreado(Guid idAeropuertoOrigen, Guid idAeropuertoDestino, Guid idVuelo) : base(DateTime.Now)
        {
            IdAeropuertoOrigen = idAeropuertoOrigen;
            IdAeropuertoDestino = idAeropuertoDestino;
            IdVuelo = idVuelo;
        }
    }
}
