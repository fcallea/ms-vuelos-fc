using Moq;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vuelos.Application.Services;
using Vuelos.Application.UseCases.Command.Vuelos.CrearDestinoVuelo;
using Vuelos.Application.UseCases.Command.Vuelos.CrearVuelo;
using Vuelos.Domain.Event;
using Vuelos.Domain.Factories;
using Vuelos.Domain.Model.Vuelos;
using Vuelos.Domain.Repositories;
using Xunit;

namespace Vuelos.Test.Application.UseCases.Command.Vuelos.CrearDestinoVuelo
{
    public class CrearDestinoVueloHandler_Tests
    {
        private readonly Mock<IVueloRepository> vueloRepository;
        private readonly Mock<IVueloService> vueloService;
        private readonly Mock<IVueloFactory> vueloFactory;
        private readonly Mock<IUnitOfWork> unitOfWork;

        Guid IdAeropuertoOrigen = Guid.NewGuid();
        Guid IdAeropuertoDestino = Guid.NewGuid();
        int nroVuelo = 0;
        decimal millasVuelo = 0.0m;
        private Vuelo vueloTest;

        public CrearDestinoVueloHandler_Tests()
        {
            vueloRepository = new Mock<IVueloRepository>();
            vueloService = new Mock<IVueloService>();
            vueloFactory = new Mock<IVueloFactory>();
            unitOfWork = new Mock<IUnitOfWork>();

            vueloTest = new Vuelo(IdAeropuertoOrigen, IdAeropuertoDestino, nroVuelo, millasVuelo);

        }

        [Fact]
        public void CrearDestinoVueloHandler_HandleCorrectly()
        {
            vueloFactory.Setup(factory => factory.CrearDestinoVuelo(IdAeropuertoOrigen, IdAeropuertoDestino, nroVuelo, millasVuelo))
                .Returns(vueloTest);

            var objHandler = new CrearDestinoVueloHandler(
                unitOfWork.Object,
                vueloFactory.Object,
                vueloRepository.Object,
                vueloService.Object
            );

            var objRequest = new CrearDestinoVueloCommand(IdAeropuertoOrigen, IdAeropuertoDestino);
            
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
            Assert.IsType<Guid>(result.Result);

            var domainEventList = (List<DomainEvent>)vueloTest.DomainEvents;
            Assert.Single(domainEventList);
            Assert.IsType<DestinoVueloCreado>(domainEventList[0]);

            Guid auxIdVuelo = Guid.NewGuid();
            DestinoVueloCreado d = new DestinoVueloCreado(auxIdVuelo, IdAeropuertoOrigen, IdAeropuertoDestino);
            Assert.Equal(d.IdVuelo, auxIdVuelo);
            Assert.Equal(d.IdAeropuertoOrigen, IdAeropuertoOrigen);
            Assert.Equal(d.IdAeropuertoDestino, IdAeropuertoDestino);

            vueloTest.CambiarEstado("TEST");
            Assert.NotNull(vueloTest);

            Guid idTripulacion = Guid.NewGuid();
            Guid idAeronave = Guid.NewGuid();

            bool esNuevo = false;
            DateTime fechacreacion = DateTime.Now;
            var itinerario = vueloTest.AgregarItinerarioVuelo(idTripulacion, idAeronave, fechacreacion, "A", "01", DateTime.Now, out esNuevo);
            Assert.True(esNuevo);
            itinerario = vueloTest.AgregarItinerarioVuelo(idTripulacion, idAeronave, fechacreacion, "A", "01", DateTime.Now, out esNuevo);
            Assert.False(esNuevo);
            itinerario.SetNroAsientosHabilitados(50);
            Assert.True(itinerario.NroAsientosHabilitados > 0);
            itinerario.ConsolidarVueloAsignado();

            ICollection<ItinerarioVuelo> listaitinerarios = (ICollection<ItinerarioVuelo>)vueloTest.ListaItinerariosVuelo;
            Assert.NotNull(listaitinerarios);

            VueloAsignado vasig = new VueloAsignado(auxIdVuelo, idTripulacion, idAeronave);
            Assert.Equal(vasig.IdVuelo, auxIdVuelo);
            Assert.Equal(vasig.IdTripulacion, idTripulacion);
            Assert.Equal(vasig.IdAeronave, idAeronave);

        }

        [Fact]
        public void CrearDestinoVueloHandler_Handle_Fail()
        {
            // Failing by returning null values
            var objHandler = new CrearDestinoVueloHandler(
                unitOfWork.Object,
                vueloFactory.Object,
                vueloRepository.Object,
                vueloService.Object
            );
            var objRequest = new CrearDestinoVueloCommand(
               IdAeropuertoOrigen, IdAeropuertoDestino
           );
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);

        }
    }
}
