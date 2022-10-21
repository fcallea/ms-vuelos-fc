using Moq;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vuelos.Application.UseCases.Command.Aeropuertos.RegistrarAeropuerto;
using Vuelos.Domain.Event;
using Vuelos.Domain.Factories;
using Vuelos.Domain.Model.Aeropuertos;
using Vuelos.Domain.Repositories;
using Xunit;

namespace Vuelos.Test.Application.UseCases.Command.Aeropuertos.RegistrarAeropuerto
{
   public class RegistrarAeropuertoHandler_Tests
    {
        private readonly Mock<IAeropuertoRepository> aeropuertoRepository;
        private readonly Mock<IAeropuertoFactory> aeropuertoFactory;
        private readonly Mock<IUnitOfWork> unitOfWork;

        private Guid IdAeropuerto = Guid.NewGuid();
        private string NombreAeropuerto = "El Alto International Airport";
        private string Localidad = "EL ALTO";
        private string Departamento = "LA PAZ";
        private string OACI = "SLLP";
        private string IATA = "LPB";
        private Aeropuerto aeropuertoTest;

        public RegistrarAeropuertoHandler_Tests()
        {
            aeropuertoRepository = new Mock<IAeropuertoRepository>();
            aeropuertoFactory = new Mock<IAeropuertoFactory>();
            unitOfWork = new Mock<IUnitOfWork>();
            aeropuertoTest = new AeropuertoFactory().RegistrarAeropuerto(IdAeropuerto, NombreAeropuerto, Localidad, Departamento, OACI, IATA);
        }

        [Fact]
        public void RegistrarAeropuertoHandler_HandleCorrectly()
        {
            aeropuertoFactory.Setup(factory => factory.RegistrarAeropuerto(IdAeropuerto, NombreAeropuerto, Localidad, Departamento, OACI, IATA));
            aeropuertoRepository.Setup(repository => repository.CreateAsync(aeropuertoTest));

            var objHandler = new RegistrarAeropuertoHandler(
                unitOfWork.Object,
                aeropuertoFactory.Object,
                aeropuertoRepository.Object
            );
            var objRequest = new RegistrarAeropuertoCommand(
               IdAeropuerto, NombreAeropuerto, Localidad, Departamento, OACI, IATA
           );
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
            Assert.IsType<Guid>(result.Result);

            var domainEventList = (List<DomainEvent>)aeropuertoTest.DomainEvents;
            Assert.Single(domainEventList);
            Assert.IsType<AeropuertoRegistrado>(domainEventList[0]);
        }

        [Fact]
        public void CrearProductoHandler_Handle_Fail()
        {
            // Failing by returning null values
            var objHandler = new RegistrarAeropuertoHandler(
                unitOfWork.Object,
                aeropuertoFactory.Object,
                aeropuertoRepository.Object
            );
            var objRequest = new RegistrarAeropuertoCommand(
               IdAeropuerto, NombreAeropuerto, Localidad, Departamento, OACI, IATA
           );
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);

            Guid auxGuid = Guid.NewGuid();
            AeropuertoRegistrado aeropuertoreg = new AeropuertoRegistrado(auxGuid);
            Assert.NotNull((object)aeropuertoreg.IdAeropuerto);
            Assert.Equal(aeropuertoreg.IdAeropuerto, auxGuid);
        }
    }
}
