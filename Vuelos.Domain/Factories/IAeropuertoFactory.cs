using System;
using Vuelos.Domain.Model.Aeropuertos;

namespace Vuelos.Domain.Factories
{
    public interface IAeropuertoFactory
    {
        Aeropuerto RegistrarAeropuerto(Guid IdAeropuerto, string NombreAeropuerto, string Localidad, string Departamento, string OACI, string IATA);
    }
}