using System;
using Vuelos.Domain.Model.Vuelos;

namespace Vuelos.Domain.Factories
{
    public interface IVueloFactory
    {
        Vuelo Create(Guid idAeropuertoOrigen, Guid idAeropuertoDestino, string nroVuelo);
    }
}