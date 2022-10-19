using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Application.UseCases.Command.Vuelos.AsignarVuelo;
using Vuelos.Domain.Model.Vuelos;
using Xunit;

namespace Vuelos.Test.Application.UseCases.Command.Vuelos.AsignarVuelo
{
    public class AsignarVueloCommand_Tests
    {
        [Fact]
        public void IsRequest_Valid()
        {
            Guid idAeropuertoOrigen = Guid.NewGuid();
            Guid idAeropuertoDestino = Guid.NewGuid();
            int nroVuelo = 1005;
            decimal millasVuelo = 0.0m;
            var objVuelo = new Vuelo(idAeropuertoOrigen, idAeropuertoDestino, nroVuelo, millasVuelo);

            var itinerariosListTest = MockFactory.GetListaItinerarios();
            var command = new AsignarVueloCommand(objVuelo.Id,itinerariosListTest);

            Assert.Equal(3, command.ListaItinerarios.Count);
            Assert.NotNull((object)command.IdVuelo);
        }

        [Fact]
        public void TestConstructor_IsPrivate()
        {
            var command = (AsignarVueloCommand)Activator.CreateInstance(typeof(AsignarVueloCommand), true);
            Assert.Null(command.ListaItinerarios);
        }
    }
}
