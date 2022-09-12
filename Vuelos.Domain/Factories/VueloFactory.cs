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
        public Vuelo Create(Guid idAeropuertoOrigen, Guid idAeropuertoDestino, string nroVuelo)
        {
            return new Vuelo(idAeropuertoOrigen, idAeropuertoDestino, nroVuelo);
        }
    }
}
