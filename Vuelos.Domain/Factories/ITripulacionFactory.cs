using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Domain.Model.Tripulaciones;

namespace Vuelos.Domain.Factories
{
    public interface ITripulacionFactory
    {
        Tripulacion RegistrarTripulacion(Guid IdAeronave, string TripulacionNombre, string EstadoAeronave);
    }
}
