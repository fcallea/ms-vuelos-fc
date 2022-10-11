using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Domain.Model.Aeropuertos;

namespace Vuelos.Domain.Factories
{
    public class AeropuertoFactory : IAeropuertoFactory
    {
        public Aeropuerto RegistrarAeropuerto(Guid IdAeropuerto, string NombreAeropuerto, string Localidad, string Departamento, string OACI, string IATA)
        {
            return new Aeropuerto(IdAeropuerto, NombreAeropuerto, Localidad, Departamento, OACI, IATA);
        }
    }
}
