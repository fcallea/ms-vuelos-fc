using System;
using Vuelos.Domain.Model.Vuelos;

namespace Vuelos.Domain.Factories
{
    public interface IVueloFactory
    {
        Vuelo CrearDestinoVuelo(Guid idAeropuertoOrigen, Guid idAeropuertoDestino, int nroVuelo, decimal millasVuelo);
    }
}