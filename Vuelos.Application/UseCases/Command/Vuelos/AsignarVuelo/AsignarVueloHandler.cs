using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vuelos.Application.Dto.Vuelo;
using Vuelos.Application.Services;
using Vuelos.Domain.Factories;
using Vuelos.Domain.Model.Vuelos;
using Vuelos.Domain.Repositories;

namespace Vuelos.Application.UseCases.Command.Vuelos.AsignarVuelo
{
    public class AsignarVueloHandler : IRequestHandler<AsignarVueloCommand, Guid>
    {
        private readonly IVueloRepository vueloRepository;
        private readonly IVueloService vueloService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IVueloFactory vueloFactory;
        private readonly ILogger<AsignarVueloCommand> _logger;

        public AsignarVueloHandler(
              IUnitOfWork unitOfWork
            , IVueloFactory vueloFactory
            , IVueloRepository vueloRepository
            , IVueloService vueloService
            , ILogger<AsignarVueloCommand> logger
             )
        {
            this.vueloRepository = vueloRepository;
            this.vueloService = vueloService;
            this.unitOfWork = unitOfWork;
            this.vueloFactory = vueloFactory;
            _logger = logger;
        }

        public async Task<Guid> Handle(AsignarVueloCommand request, CancellationToken cancellationToken)
        {
            var objVuelo = await vueloRepository.FindByIdVueloAsync(request.IdVuelo);           
            foreach (var itinerario in request.ListaItinerarios)
            {
                bool esNuevo = false;
                var objItinerario = objVuelo.AgregarItinerarioVuelo(itinerario.IdTripulacion, itinerario.IdAeronave, itinerario.FechaHoraPartida, itinerario.ZonaAbordaje, itinerario.NroPuertaAbordaje, itinerario.FechaHoraAbordaje, out esNuevo);
                //await vueloRepository.UpdateItinerarioAsync(objItinerario);
                var itinerarioBD = objVuelo.ListaItinerariosVuelo.FirstOrDefault(x => x.IdTripulacion == itinerario.IdTripulacion && x.IdAeronave == itinerario.IdAeronave);
                if (esNuevo)
                {
                    await vueloRepository.SaveItinerarioAsync(objItinerario);
                }
                else
                {
                    await vueloRepository.UpdateItinerarioAsync(objItinerario);
                }
            }
            //await vueloRepository.CreateAsync(objVuelo);
            //await vueloRepository.UpdateAsync(objVuelo);

            await unitOfWork.Commit();

            return objVuelo.Id;
        }
    }
}
