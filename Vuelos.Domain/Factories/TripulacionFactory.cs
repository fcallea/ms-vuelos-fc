using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Domain.Model.Tripulaciones;

namespace Vuelos.Domain.Factories
{
    public class TripulacionFactory : ITripulacionFactory
    {
        public Tripulacion RegistrarTripulacion(Guid IdAeronave, string EstadoAeronave)
        {
            return new Tripulacion(IdAeronave, EstadoAeronave);
        }
    }
}
