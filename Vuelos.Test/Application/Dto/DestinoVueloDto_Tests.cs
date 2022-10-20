using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Application.Dto.Vuelo;
using Xunit;

namespace Vuelos.Test.Application.Dto
{
    public class DestinoVueloDto_Tests
    {
        [Fact]
        public void DestinoVueloDto_CheckPropertiesValid()
        {
            var Id = Guid.NewGuid();
            var DepartamentoOrigen = "LA PAZ";
            var IdAeropuertoOrigen = Guid.NewGuid();
            var NombreAeropuertoOrigen = "AEROPUERTO 1";
            var DepartamentoDestino = "TARIJA";
            var IdAeropuertoDestino = Guid.NewGuid();
            var NombreAeropuertoDestino = "AEROPUERTO 2";


            var destinoVuelo = new DestinoVueloDto();

            destinoVuelo.Id = Id;
            destinoVuelo.DepartamentoOrigen = DepartamentoOrigen;
            destinoVuelo.IdAeropuertoOrigen = IdAeropuertoOrigen;
            destinoVuelo.NombreAeropuertoOrigen = NombreAeropuertoOrigen;
            destinoVuelo.DepartamentoDestino = DepartamentoDestino;
            destinoVuelo.IdAeropuertoDestino = IdAeropuertoDestino;
            destinoVuelo.NombreAeropuertoDestino = NombreAeropuertoDestino;


            Assert.Equal(Id, destinoVuelo.Id);
            Assert.Equal(DepartamentoOrigen, destinoVuelo.DepartamentoOrigen);
            Assert.Equal(IdAeropuertoOrigen, destinoVuelo.IdAeropuertoOrigen);
            Assert.Equal(NombreAeropuertoOrigen, destinoVuelo.NombreAeropuertoOrigen);
            Assert.Equal(DepartamentoDestino, destinoVuelo.DepartamentoDestino);
            Assert.Equal(IdAeropuertoDestino, destinoVuelo.IdAeropuertoDestino);
            Assert.Equal(NombreAeropuertoDestino, destinoVuelo.NombreAeropuertoDestino);
        }
    }
}
