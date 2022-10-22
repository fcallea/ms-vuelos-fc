using Microsoft.Extensions.Logging;
using Moq;
using Shared.Rabbitmq.BusRabbit;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vuelos.Application.Dto.Vuelo;
using Vuelos.Application.Services;
using Vuelos.Application.UseCases.Command.Vuelos.AsignarVuelo;
using Vuelos.Domain.Event;
using Vuelos.Domain.Factories;
using Vuelos.Domain.Model.Vuelos;
using Vuelos.Domain.Repositories;
using Xunit;
using static Moq.It;

namespace Vuelos.Test.Application.UseCases.Command.Vuelos.AsignarVuelo
{
    public class AsignarVueloHandler_Tests
    {
        private readonly Mock<IVueloRepository> _vueloRepository;
        private readonly Mock<ITripulacionRepository> _tripulacionRepository;
        private readonly Mock<IAeronaveRepository> _aeronaveRepository;
        private readonly Mock<IAeropuertoRepository> _aeropuertoRepository;
        private readonly Mock<ILogger<AsignarVueloCommand>> logger;
        private readonly Mock<IVueloService> _vueloService;
        private readonly Mock<IVueloFactory> _vueloFactory;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<IRabbitEventBus> _eventBus;


        private Guid idAeropuertoOrigen = Guid.NewGuid();
        private Guid idAeropuertoDestino = Guid.NewGuid();
        private int nroVueloTest = 10;
        private decimal millasVueloTest = 100;
        private Vuelo vueloTest;
        private List<ItinerarioVueloDto> listaItinerariosTest = MockFactory.GetListaItinerarios();

        public AsignarVueloHandler_Tests()
        {
            _vueloRepository = new Mock<IVueloRepository>();
            _tripulacionRepository = new Mock<ITripulacionRepository>();
            _aeronaveRepository = new Mock<IAeronaveRepository>();
            _aeropuertoRepository = new Mock<IAeropuertoRepository>();
            logger = new Mock<ILogger<AsignarVueloCommand>>();
            _vueloService = new Mock<IVueloService>();
            _vueloFactory = new Mock<IVueloFactory>();
            _unitOfWork = new Mock<IUnitOfWork>();
            vueloTest = new VueloFactory().CrearDestinoVuelo(Guid.NewGuid(), Guid.NewGuid(), 123, 0.0m);
        }

        [Fact]
        public void AsignarVueloHandler_HandleCorrectly()
        {
            _vueloService.Setup(_vueloService => _vueloService.GenerarNroVueloAsync(idAeropuertoOrigen, idAeropuertoDestino)).Returns(Task.FromResult(nroVueloTest));
            Assert.NotEqual(0,nroVueloTest);
            _vueloService.Setup(_vueloService => _vueloService.CalcularMillasVueloAsync(idAeropuertoOrigen, idAeropuertoDestino)).Returns(Task.FromResult(millasVueloTest));
            Assert.NotEqual(0, millasVueloTest);
            _vueloFactory.Setup(_vueloFactory => _vueloFactory.CrearDestinoVuelo(idAeropuertoOrigen, idAeropuertoDestino, nroVueloTest, millasVueloTest)).Returns(vueloTest);
            _vueloRepository.Setup(_vueloRepository => _vueloRepository.CreateAsync(vueloTest));

            var objHandler = new AsignarVueloHandler(
             _unitOfWork.Object,
             _vueloFactory.Object,
             _vueloRepository.Object, 
             _tripulacionRepository.Object, _aeronaveRepository.Object, _aeropuertoRepository.Object,
             _vueloService.Object,
             logger.Object,
             _eventBus.Object
            );

            var objRequest = new AsignarVueloCommand(
                vueloTest.Id,
                listaItinerariosTest
            );
 
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
            Assert.IsType<Guid>(result.Result);

            _vueloRepository.Verify(mock => mock.CreateAsync(IsAny<Vuelo>()), Times.Once);
            _unitOfWork.Verify(mock => mock.Commit(), Times.Once);
            Assert.IsType<Guid>(result.Result);

            var domainEventList = (List<DomainEvent>)vueloTest.DomainEvents;
            Assert.Equal(4, domainEventList.Count);
            Assert.IsType<VueloAsignado>(domainEventList[0]);
            Assert.IsType<VueloAsignado>(domainEventList[1]);
            Assert.IsType<VueloAsignado>(domainEventList[2]);
        }
        [Fact]
        public void AsignarVueloHandler_Handle_Fail()
        {
            // Failing by returning null values
            var objHandler = new AsignarVueloHandler(
             _unitOfWork.Object,
             _vueloFactory.Object,
             _vueloRepository.Object,
             _tripulacionRepository.Object, _aeronaveRepository.Object, _aeropuertoRepository.Object,
             _vueloService.Object,
             logger.Object,
             _eventBus.Object
           );

            var objRequest = new AsignarVueloCommand(
                vueloTest.Id,
                listaItinerariosTest
           );
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
            logger.Verify(mock => mock.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.Is<EventId>(eventId => eventId.Id == 0),
                It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al crear Vuelo"),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>())
            , Times.Once);
        }
    }
}
