using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Application.UseCases.Command.Aeronaves.RegistrarAeronave;
using Xunit;

namespace Vuelos.Test.Application.UseCases.Command.Aeronaves.RegistrarAeronave
{
    public class RegistrarAeronaveCommand_Tests
    {
        [Fact]
        public void RegistrarAeronaveCommand_DataValid()
        {
            var Id = Guid.NewGuid();
            var NroAsientos = 30;
            var EstadoAeronave = "ACTIVO";
            var Marca = "Marca";
            var Modelo = "Modelo";
            var Comentario = "Comentario";

            var command = new RegistrarAeronaveCommand(Id, NroAsientos, EstadoAeronave,Marca,Modelo,Comentario);

            Assert.Equal(Id, command.Id);
            Assert.Equal(NroAsientos, command.NroAsientos);
            Assert.Equal(EstadoAeronave, command.EstadoAeronave);
            Assert.Equal(Marca, command.Marca);
            Assert.Equal(Modelo, command.Modelo);
            Assert.Equal(Comentario, command.Comentario);

        }


        [Fact]
        public void TestConstructor_IsPrivate()
        {
            var command = (RegistrarAeronaveCommand)Activator.CreateInstance(typeof(RegistrarAeronaveCommand), true);
            Assert.Null((object)command.Id);
            Assert.Equal(0, command.NroAsientos);
            Assert.Equal("ACTIVO", command.EstadoAeronave);
            Assert.Equal("Marca", command.Marca);
            Assert.Equal("Modelo", command.Modelo);
            Assert.Equal("Comentario", command.Comentario);
        }

    }
}
