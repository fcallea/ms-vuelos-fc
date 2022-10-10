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
            Guid reqIdAeropuertoOrigen = request.IdAeropuertoOrigen;
            Guid reqIdAeropuertoDestino = request.IdAeropuertoDestino;
            int nroVuelo = 0;
            decimal millasVuelo = 0;

            var vuelo = await vueloRepository.FindByIdVueloPorDestinoAsync(request.IdAeropuertoOrigen, request.IdAeropuertoDestino);

            if (vuelo is null)
            {
                nroVuelo = await vueloService.GenerarNroVueloAsync(reqIdAeropuertoOrigen, reqIdAeropuertoDestino);
                millasVuelo = await vueloService.CalcularMillasVueloAsync(reqIdAeropuertoOrigen, reqIdAeropuertoDestino);

                vuelo = vueloFactory.CrearDestinoVuelo(reqIdAeropuertoOrigen, reqIdAeropuertoDestino, nroVuelo, millasVuelo);
                await vueloRepository.CreateAsync(vuelo);
            }

            await unitOfWork.Commit();

            return vuelo.Id;
        }
    }
}
