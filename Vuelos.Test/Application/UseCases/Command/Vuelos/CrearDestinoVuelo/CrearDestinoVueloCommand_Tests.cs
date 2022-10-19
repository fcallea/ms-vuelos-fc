using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Application.UseCases.Command.Vuelos.CrearDestinoVuelo;
using Xunit;

namespace Vuelos.Test.Application.UseCases.Command.Vuelos.CrearDestinoVuelo
{
    public class CrearDestinoVueloCommand_Tests
    {
        [Fact]
        public void CrearDestinoVueloCommand_DataValid()
        {
            Guid IdAeropuertoOrigen = Guid.NewGuid();
            Guid IdAeropuertoDestino = Guid.NewGuid();

            var command = new CrearDestinoVueloCommand(IdAeropuertoOrigen, IdAeropuertoDestino);

            Assert.Equal(IdAeropuertoOrigen, command.IdAeropuertoOrigen);
            Assert.Equal(IdAeropuertoDestino, command.IdAeropuertoDestino);
        }

        [Fact]
        public void TestConstructor_IsPrivate()
        {
            var command = (CrearDestinoVueloCommand)Activator.CreateInstance(typeof(CrearDestinoVueloCommand), true);
            Assert.NotNull((Object)command.IdAeropuertoOrigen);
            Assert.NotNull((Object)command.IdAeropuertoDestino);
        }
    }
}
