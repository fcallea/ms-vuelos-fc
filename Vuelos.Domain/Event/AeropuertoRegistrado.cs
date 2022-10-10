using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Domain.Event
{
    public record AeropuertoRegistrado : DomainEvent
    {
        public Guid IdAeropuerto { get; }

        public AeropuertoRegistrado(Guid idAeropuerto) : base(DateTime.Now)
        {
            IdAeropuerto = idAeropuerto;
        }
    }
}
