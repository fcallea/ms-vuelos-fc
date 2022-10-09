using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vuelos.Application.Services;
using Vuelos.Domain.Factories;
using Vuelos.Domain.Repositories;

namespace Vuelos.Application.UseCases.Command.Vuelos.CrearVuelo
{
    public class CrearDestinoVueloHandler : IRequestHandler<CrearDestinoVueloCommand, Guid>
    {
        private readonly IVueloRepository vueloRepository;
        private readonly IVueloService vueloService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IVueloFactory vueloFactory;

        public CrearDestinoVueloHandler(
              IUnitOfWork unitOfWork
            , IVueloFactory vueloFactory
            , IVueloRepository vueloRepository
            , IVueloService vueloService
             )
        {
            this.vueloRepository = vueloRepository;
            this.vueloService = vueloService;
            this.unitOfWork = unitOfWork;
            this.vueloFactory = vueloFactory;
        }

        public async Task<Guid> Handle(CrearDestinoVueloCommand request, CancellationToken cancellationToken)
        {
            var vuelo = await vueloRepository.FindByIdVueloPorDestinoAsync(request.IdAeropuertoOrigen, request.IdAeropuertoDestino);

            int nroVuelo = await vueloService.GenerarNroVueloAsync(request.IdAeropuertoOrigen, request.IdAeropuertoDestino);
            decimal millasVuelo = await vueloService.CalcularMillasVueloAsync(request.IdAeropuertoOrigen, request.IdAeropuertoDestino);

            var destinoVuelo = vueloFactory.CrearDestinoVuelo(request.IdAeropuertoOrigen, request.IdAeropuertoDestino, nroVuelo, millasVuelo);

            await vueloRepository.CreateAsync(destinoVuelo);

            await unitOfWork.Commit();

            return destinoVuelo.Id;
        }
    }
}
