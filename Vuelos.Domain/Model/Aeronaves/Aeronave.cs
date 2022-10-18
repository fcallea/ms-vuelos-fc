using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Domain.Model.Aeronaves
{
    public class Aeronave : AggregateRoot<Guid>
    {
        public int NroAsientos { get; set; }
        public string EstadoAeronave { get; set; }

        private Aeronave() { }

        internal Aeronave(Guid id, int nroAsientos, string estadoAeronave)
        {
            Id = id;
            NroAsientos = nroAsientos;
            EstadoAeronave = estadoAeronave;
        }

        /*
        public void ConsolidarAeronave()
        {
            var evento = new AeronaveRegistrada(Id);
            AddDomainEvent(evento);
        }
        */
    }
}
