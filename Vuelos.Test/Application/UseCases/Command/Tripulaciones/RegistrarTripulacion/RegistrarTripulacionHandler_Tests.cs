using Moq;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vuelos.Application.UseCases.Command.Tripulaciones.RegistrarTripulacion;
using Vuelos.Domain.Factories;
using Vuelos.Domain.Model.Tripulaciones;
using Vuelos.Domain.Repositories;
using Xunit;

namespace Vuelos.Test.Application.UseCases.Command.Tripulaciones.RegistrarTripulacion
{
    public class RegistrarTripulacionHandler_Tests
    {
        private readonly Mock<ITripulacionRepository> tripulacionRepository;
        private readonly Mock<ITripulacionFactory> tripulacionFactory;
        private readonly Mock<IUnitOfWork> unitOfWork;


        private Guid Id = Guid.NewGuid();
        private int EstadoTripulacion = 1;
        private int TripulacionId = 1;
        private string TripulacionNombre = "Tripulantes";
        private string TxtEstadoTripulacion = "PENDIENTE";
        private Tripulacion tripulacionTest;

        public RegistrarTripulacionHandler_Tests()
        {
            tripulacionRepository = new Mock<ITripulacionRepository>();
            tripulacionFactory = new Mock<ITripulacionFactory>();
            unitOfWork = new Mock<IUnitOfWork>();

            if (EstadoTripulacion == 1)
                TxtEstadoTripulacion = "ACTIVO";
            tripulacionTest = new TripulacionFactory().RegistrarTripulacion(Id, TripulacionNombre, TxtEstadoTripulacion);
        }

        [Fact]
        public void RegistrarAeronaveHandler_HandleCorrectly()
        {
            tripulacionFactory.Setup(factory => factory.RegistrarTripulacion(Id, TripulacionNombre, TxtEstadoTripulacion)).Returns(tripulacionTest);
            tripulacionRepository.Setup(repository => repository.CreateAsync(tripulacionTest));

            var objHandler = new RegistrarTripulacionHandler(
                unitOfWork.Object,
                tripulacionFactory.Object,
                tripulacionRepository.Object
            );
            var objRequest = new RegistrarTripulacionCommand(
               Id, TripulacionNombre, EstadoTripulacion, TripulacionId
           );
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
            Assert.IsType<Guid>(result.Result);

            var domainEventList = (List<DomainEvent>)tripulacionTest.DomainEvents;
            Assert.Single(domainEventList);
            //Assert.IsType<AeronaveRegistrada>(domainEventList[0]);
        }
        [Fact]
        public void CrearProductoHandler_Handle_Fail()
        {
            // Failing by returning null values
            var objHandler = new RegistrarTripulacionHandler(
                unitOfWork.Object,
                tripulacionFactory.Object,
                tripulacionRepository.Object
            );
            var objRequest = new RegistrarTripulacionCommand(
               Id, TripulacionNombre, EstadoTripulacion, TripulacionId
           );
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
        }
    }
}
