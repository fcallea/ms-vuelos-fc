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
            var Id = Guid.NewGuid();
            var TripulacionNombre = "tripulantes";
            var EstadoTripulacion = 1;

            var command = new RegistrarTripulacionCommand(Id, TripulacionNombre, EstadoTripulacion);

            Assert.Equal(Id, command.Id);
            Assert.Equal(TripulacionNombre, command.TripulacionNombre);
            Assert.Equal(EstadoTripulacion, command.EstadoTripulacion);
        }


        [Fact]
        public void TestConstructor_IsPrivate()
        {
            var command = (RegistrarTripulacionCommand)Activator.CreateInstance(typeof(RegistrarTripulacionCommand), true);
            Assert.Null((object)command.Id);
            Assert.Equal("tripulantes", command.TripulacionNombre);
            Assert.Equal(0, command.EstadoTripulacion);
        }
    }
}
