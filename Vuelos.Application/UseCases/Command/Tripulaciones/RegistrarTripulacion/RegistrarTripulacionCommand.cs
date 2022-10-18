using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Application.UseCases.Command.Tripulaciones.RegistrarTripulacion
{
    public class RegistrarTripulacionCommand : IRequest<Guid>
    {
        public Guid Id { get; private set; }
        public string EstadoTripulacion { get; private set; }

        private RegistrarTripulacionCommand()
        {
        }
        public RegistrarTripulacionCommand(Guid id, string estadoTripulacion)
        {
            Id = id;
            EstadoTripulacion = estadoTripulacion;
        }
    }
}
