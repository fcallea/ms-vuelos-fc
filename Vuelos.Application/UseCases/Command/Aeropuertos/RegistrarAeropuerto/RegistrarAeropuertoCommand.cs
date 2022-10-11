using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Application.UseCases.Command.Aeropuertos.RegistrarAeropuerto
{
    public class RegistrarAeropuertoCommand : IRequest<Guid>
    {
        public Guid IdAeropuerto { get; private set; }
        public string NombreAeropuerto { get; private set; }
        public string Localidad { get; private set; }
        public string Departamento { get; private set; }
        public string OACI { get; private set; }
        public string IATA { get; private set; }

        private RegistrarAeropuertoCommand()
        {
        }
        public RegistrarAeropuertoCommand(Guid idAeropuerto, string nombreAeropuerto, string localidad, string departamento, string oaci, string iata)
        {
            IdAeropuerto = idAeropuerto;
            NombreAeropuerto = nombreAeropuerto;
            Localidad = localidad;
            Departamento = departamento;
            OACI = oaci;
            IATA = iata;
        }
    }
}
