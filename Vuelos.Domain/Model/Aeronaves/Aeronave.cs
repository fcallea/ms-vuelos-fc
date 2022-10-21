using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Domain.Model.Aeronaves
{
    public class Aeronave : AggregateRoot<Guid>
    {
        public int NroAsientos { get; set; }
        public string EstadoAeronave { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Comentario { get; set; }


        [ExcludeFromCodeCoverage]
        private Aeronave() { }

        internal Aeronave(Guid id, int nroAsientos, string estadoAeronave, string marca, string modelo, string comentario)
        {
            Id = id;
            NroAsientos = nroAsientos;
            EstadoAeronave = estadoAeronave;
            Marca = marca;
            Modelo = modelo;
            Comentario = comentario;
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
