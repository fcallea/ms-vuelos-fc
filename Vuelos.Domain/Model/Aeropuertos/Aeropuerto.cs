using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Domain.Event;

namespace Vuelos.Domain.Model.Aeropuertos
{
    public class Aeropuerto : AggregateRoot<Guid>
    {
        public string NombreAeropuerto { get; set; }
        public string Localidad { get; set; }
        public string Departamento { get; set; }
        public string OACI { get; set; }
        public string IATA { get; set; }

        private Aeropuerto() { }

        internal Aeropuerto(Guid id, string NombreAeropuerto, string Localidad, string Departamento, string OACI, string IATA)
        {
            Id = id;
            this.NombreAeropuerto = NombreAeropuerto;
            this.Localidad = Localidad;
            this.Departamento = Departamento;
            this.OACI = OACI;
            this.IATA = IATA;
        }

        public void ConsolidarAeropuerto()
        {
            var evento = new AeropuertoRegistrado(Id);
            AddDomainEvent(evento);
        }
    }
}
