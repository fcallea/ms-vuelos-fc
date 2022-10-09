using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Domain.Model.Vuelos;

namespace Vuelos.Domain.Factories
{
    public class VueloFactory : IVueloFactory
    {
        public Vuelo CrearDestinoVuelo (Guid idAeropuertoOrigen, Guid idAeropuertoDestino, int nroVuelo, decimal millasVuelo)
        {
            return new Vuelo(idAeropuertoOrigen, idAeropuertoDestino, nroVuelo, millasVuelo);
        }
    }
}
