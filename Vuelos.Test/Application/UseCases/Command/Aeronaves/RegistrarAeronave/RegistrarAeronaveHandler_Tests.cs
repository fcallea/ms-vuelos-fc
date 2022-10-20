using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Application.UseCases.Command.Aeronaves.RegistrarAeronave;
using Vuelos.Domain.Factories;
using Vuelos.Domain.Model.Aeronaves;
using Vuelos.Domain.Repositories;
using Xunit;
using System.Threading;
using ShareKernel.Core;

namespace Vuelos.Test.Application.UseCases.Command.Aeronaves.RegistrarAeronave
{
    public class RegistrarAeronaveHandler_Tests
    {
        private readonly Mock<IAeronaveRepository> aeronaveRepository;
        private readonly Mock<IAeronaveFactory> aeronaveFactory;
        private readonly Mock<IUnitOfWork> unitOfWork;


        private Guid Id = Guid.NewGuid();
        private int NroAsientos = 30;
        private string EstadoAeronave = "ACTIVO";
        private Aeronave aeronaveTest;

        public RegistrarAeronaveHandler_Tests()
        {
            aeronaveRepository = new Mock<IAeronaveRepository>();
            aeronaveFactory = new Mock<IAeronaveFactory>();
            unitOfWork = new Mock<IUnitOfWork>();
            aeronaveTest = new AeronaveFactory().RegistrarAeronave(Id, NroAsientos, EstadoAeronave);

        }
        [Fact]
        public void RegistrarAeronaveHandler_HandleCorrectly()
        {
            aeronaveFactory.Setup(factory => factory.RegistrarAeronave(Id, NroAsientos, EstadoAeronave)).Returns(aeronaveTest);
            aeronaveRepository.Setup(repository => repository.CreateAsync(aeronaveTest));

            var objHandler = new RegistrarAeronaveHandler(
                unitOfWork.Object,
                aeronaveFactory.Object,
                aeronaveRepository.Object                           
            );
            var objRequest = new RegistrarAeronaveCommand(
               Id, NroAsientos, EstadoAeronave
           );
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
            Assert.IsType<Guid>(result.Result);

            var domainEventList = (List<DomainEvent>)aeronaveTest.DomainEvents;
            Assert.Single(domainEventList);
            //Assert.IsType<AeronaveRegistrada>(domainEventList[0]);
        }
        [Fact]
        public void CrearProductoHandler_Handle_Fail()
        {
            // Failing by returning null values
            var objHandler = new RegistrarAeronaveHandler(
                unitOfWork.Object,
                aeronaveFactory.Object,
                aeronaveRepository.Object   
            );
            var objRequest = new RegistrarAeronaveCommand(
               Id, NroAsientos, EstadoAeronave
           );
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
        }
    }
}
