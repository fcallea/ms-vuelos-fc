using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Application.UseCases.Command.Aeropuertos.RegistrarAeropuerto;
using Vuelos.WebApi.Controllers;
using Xunit;

namespace Vuelos.Test.WebApi.Controller
{
    public class AeropuertoController_Tests
    {
        [Fact]
        public void ContollerTest()
        {
            var mediator = new Mock<IMediator>();
            AeropuertoController controler = new AeropuertoController(mediator.Object);
            //var result = controler.GetAeropuerto();
            //Assert.NotNull(result);


            var IdAeropuerto = Guid.NewGuid();
            var NombreAeropuerto = "El Alto International Airport";
            var Localidad = "EL ALTO";
            var Departamento = "LA PAZ";
            var OACI = "SLLP";
            var IATA = "LPB";

            var requestc = new RegistrarAeropuertoCommand(IdAeropuerto, NombreAeropuerto, Localidad, Departamento, OACI, IATA);
            var result = controler.Create(requestc);
            Assert.NotNull(result);

            var request2 = new RegistrarAeropuertoCommand(Guid.Empty, NombreAeropuerto, Localidad, Departamento, OACI, IATA);
            var result2 = controler.Create(request2);
            Assert.NotNull(result2);
        }
    }
}
