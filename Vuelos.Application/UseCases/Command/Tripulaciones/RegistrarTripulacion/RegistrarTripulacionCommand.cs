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
        public Guid TripulacionGuid { get; private set; }
        public string TripulacionNombre { get; private set; }
        public int TripulacionEstado { get; private set; }
        public int TripulacionId  { get; private set; }

        private RegistrarTripulacionCommand()
        {
        }

        public RegistrarTripulacionCommand(Guid tripulacionGuid, string tripulacionNombre, int tripulacionEstado, int tripulacionId)
        {
            TripulacionGuid = tripulacionGuid;
            TripulacionNombre = tripulacionNombre;
            TripulacionEstado = tripulacionEstado;
            TripulacionId = tripulacionId;
        }
    }
}
