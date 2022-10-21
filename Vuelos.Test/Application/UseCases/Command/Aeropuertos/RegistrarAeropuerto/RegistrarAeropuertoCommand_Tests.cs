using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Application.UseCases.Command.Aeropuertos.RegistrarAeropuerto;
using Vuelos.Application.UseCases.Command.Tripulaciones.RegistrarTripulacion;
using Xunit;

namespace Vuelos.Test.Application.UseCases.Command.Aeropuertos.RegistrarAeropuerto
{
    public class RegistrarAeropuertoCommand_Tests
    {
        [Fact]
        public void RegistrarAeropuertoCommand_DataValid()
        {
            var IdAeropuerto = Guid.NewGuid();
            var NombreAeropuerto = "El Alto International Airport";
            var Localidad = "EL ALTO";
            var Departamento = "LA PAZ";
            var OACI = "SLLP";
            var IATA = "LPB";


            var command = new RegistrarAeropuertoCommand(IdAeropuerto, NombreAeropuerto, Localidad, Departamento, OACI, IATA);

            Assert.Equal(IdAeropuerto, command.IdAeropuerto);
            Assert.Equal(NombreAeropuerto, command.NombreAeropuerto);
            Assert.Equal(Localidad, command.Localidad);
            Assert.Equal(Departamento, command.Departamento);
            Assert.Equal(OACI, command.OACI);
            Assert.Equal(IATA, command.IATA);
        }


        [Fact]
        public void TestConstructor_IsPrivate()
        {
            var command = (RegistrarAeropuertoCommand)Activator.CreateInstance(typeof(RegistrarAeropuertoCommand), true);
            Assert.Null((object)command.IdAeropuerto);
            Assert.Equal("", command.NombreAeropuerto);
            Assert.Equal("", command.Localidad);
            Assert.Equal("", command.Departamento);
            Assert.Equal("", command.OACI);
            Assert.Equal("", command.IATA);
        }

    }
}
