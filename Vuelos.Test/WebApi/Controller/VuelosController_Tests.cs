using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Application.Dto.Vuelo;
using Vuelos.Application.UseCases.Command.Aeronaves.RegistrarAeronave;
using Vuelos.Application.UseCases.Command.Tripulaciones.RegistrarTripulacion;
using Vuelos.Application.UseCases.Command.Vuelos.AsignarVuelo;
using Vuelos.Application.UseCases.Command.Vuelos.CrearDestinoVuelo;
using Vuelos.Application.UseCases.Queries.Vuelos.GetDestinoVueloById;
using Vuelos.WebApi.Controllers;
using Xunit;

namespace Vuelos.Test.WebApi.Controller
{
    public class VuelosController_Tests
    {
        [Fact]
        public void ContollerTest()
        {
            var mediator = new Mock<IMediator>();
            VuelosController controler = new VuelosController(mediator.Object);

            var req1 = new GetDestinoVueloByIdQuery();
            var res1 = controler.GetPedidoById(req1);
            Assert.NotNull(res1);

            var IdAeropuertoOrigen = Guid.NewGuid();
            var IdAeropuertoDestino = Guid.NewGuid();
            var idVuelo = Guid.NewGuid();
            List<ItinerarioVueloDto> listaItinerarios = new List<ItinerarioVueloDto>
            {
                new ItinerarioVueloDto()
                {
                    IdTripulacion = Guid.NewGuid(),
                    IdAeronave = Guid.NewGuid(),
                    ZonaAbordaje = "A",
                    NroPuertaAbordaje = "01",
                    FechaHoraAbordaje = DateTime.Now,
                    FechaHoraPartida = DateTime.Now,
                    FechaHoraLLegada = DateTime.Now,
                    TipoVuelo = "COMERCIAL"
                }
            };

            var req2 = new CrearDestinoVueloCommand(IdAeropuertoOrigen, IdAeropuertoDestino);
            var res2 = controler.Create(req2);
            Assert.NotNull(res2);

            var req3 = new AsignarVueloCommand(idVuelo, listaItinerarios);
            var res3 = controler.AsignarVuelo(req3);
            Assert.NotNull(res3);

            var mediator4 = new Mock<IMediator>();
            TripulacionController controler4 = new TripulacionController(mediator4.Object);

            var req4 = new RegistrarTripulacionCommand(Guid.NewGuid(), "Tripulantes", 1, 0);
            var res4 = controler4.GuardarTripulacion(req4);
            Assert.NotNull(res4);

            var mediator5 = new Mock<IMediator>();
            AeronaveController controler5 = new AeronaveController(mediator5.Object);

            var req5 = new RegistrarAeronaveCommand(Guid.NewGuid(), 30, "Operativo","Marca","Modelo","Comentario");
            var res5 = controler5.GuardarAeronave(req5);
            Assert.NotNull(res5);
        }
    }
}
