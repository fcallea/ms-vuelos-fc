using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Application.UseCases.Command.Tripulaciones.RegistrarTripulacion;
using Xunit;

namespace Vuelos.Test.Application.UseCases.Command.Tripulaciones.RegistrarTripulacion
{
    public class RegistrarTripulacionCommand_Tests
    {
        [Fact]
        public void RegistrarAeronaveCommand_DataValid()
        {
            var TripulacionGuid = Guid.NewGuid();
            var TripulacionNombre = "tripulantes";
            var TripulacionEstado = 1;
            var TripulacionId = 0;

            var command = new RegistrarTripulacionCommand(TripulacionGuid, TripulacionNombre, TripulacionEstado, TripulacionId);

            Assert.Equal(TripulacionGuid, command.TripulacionGuid);
            Assert.Equal(TripulacionNombre, command.TripulacionNombre);
            Assert.Equal(TripulacionEstado, command.TripulacionEstado);
            Assert.Equal(TripulacionId, command.TripulacionId);
        }


        [Fact]
        public void TestConstructor_IsPrivate()
        {
            var command = (RegistrarTripulacionCommand)Activator.CreateInstance(typeof(RegistrarTripulacionCommand), true);
            Assert.Null((object)command.TripulacionGuid);
            Assert.Equal("tripulantes", command.TripulacionNombre);
            Assert.Equal(0, command.TripulacionEstado);
            Assert.Equal(0, command.TripulacionId);
        }
    }
}
