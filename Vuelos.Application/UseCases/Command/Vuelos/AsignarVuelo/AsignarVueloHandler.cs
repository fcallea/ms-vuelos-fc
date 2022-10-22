using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Rabbitmq.BusRabbit;
using Shared.Rabbitmq.EventoQueue;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vuelos.Application.Dto.Vuelo;
using Vuelos.Application.Services;
using Vuelos.Domain.Factories;
using Vuelos.Domain.Model.Aeronaves;
using Vuelos.Domain.Model.Aeropuertos;
using Vuelos.Domain.Model.Tripulaciones;
using Vuelos.Domain.Model.Vuelos;
using Vuelos.Domain.Repositories;

namespace Vuelos.Application.UseCases.Command.Vuelos.AsignarVuelo
{
    [ExcludeFromCodeCoverage]
    public class AsignarVueloHandler : IRequestHandler<AsignarVueloCommand, Guid>
    {
        private readonly IVueloRepository _vueloRepository;
        private readonly ITripulacionRepository _tripulacionRepository;
        private readonly IAeronaveRepository _aeronaveRepository;
        private readonly IAeropuertoRepository _aeropuertoRepository;
        private readonly IVueloService _vueloService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVueloFactory _vueloFactory;
        private readonly ILogger<AsignarVueloCommand> _logger;
        private readonly IRabbitEventBus _eventBus;

        public AsignarVueloHandler(
              IUnitOfWork unitOfWork
            , IVueloFactory vueloFactory
            , IVueloRepository vueloRepository
            , ITripulacionRepository tripulacionRepository
            , IAeronaveRepository aeronaveRepository
            , IAeropuertoRepository aeropuertoRepository
            , IVueloService vueloService
            , ILogger<AsignarVueloCommand> logger
            , IRabbitEventBus eventBus
             )
        {
            _vueloRepository = vueloRepository;
            _tripulacionRepository = tripulacionRepository;
            _aeronaveRepository = aeronaveRepository;
            _aeropuertoRepository = aeropuertoRepository;
            _vueloService = vueloService;
            _unitOfWork = unitOfWork;
            _vueloFactory = vueloFactory;
            _logger = logger;
            _eventBus = eventBus;
        }

        public async Task<Guid> Handle(AsignarVueloCommand request, CancellationToken cancellationToken)
        {
            var objVuelo = await _vueloRepository.FindByIdVueloAsync(request.IdVuelo);           
            foreach (var itinerario in request.ListaItinerarios)
            {
                bool esNuevo = false;
                var objItinerario = objVuelo.AgregarItinerarioVuelo(itinerario.IdTripulacion, itinerario.IdAeronave, itinerario.FechaHoraPartida, itinerario.ZonaAbordaje, itinerario.NroPuertaAbordaje, itinerario.FechaHoraAbordaje, out esNuevo);
                var itinerarioBD = objVuelo.ListaItinerariosVuelo.FirstOrDefault(x => x.IdTripulacion == itinerario.IdTripulacion && x.IdAeronave == itinerario.IdAeronave);
                if (esNuevo)
                {
                    Aeropuerto aeropuertoOrigen = await _aeropuertoRepository.FindByIdAsync(objVuelo.IdAeropuertoOrigen);
                    Aeropuerto aeropuertoDestino = await _aeropuertoRepository.FindByIdAsync(objVuelo.IdAeropuertoDestino);

                    Tripulacion tripuAct = await _tripulacionRepository.FindByIdAsync(objItinerario.IdTripulacion);
                    Aeronave aeronAct = await _aeronaveRepository.FindByIdAsync(objItinerario.IdAeronave);
                    tripuAct.EstadoTripulacion = "ASIGNADO";
                    aeronAct.EstadoAeronave = "ASIGNADO";

                    await _tripulacionRepository.UpdateAsync(tripuAct);
                    await _aeronaveRepository.UpdateAsync(aeronAct);

                    await _vueloRepository.SaveItinerarioAsync(objItinerario);

                    string detalleVuelo = aeropuertoOrigen.Departamento + " (" + aeropuertoOrigen.IATA + ")" + " - " + aeropuertoDestino.Departamento + " (" + aeropuertoDestino.IATA + ")"; //"LA PAZ - TARIJA";
                    int cantAsientos = aeronAct.NroAsientos;

                    _eventBus.Publish(new VueloAsignadoAeronaveQueue(objItinerario.Id, objItinerario.IdTripulacion, objItinerario.IdAeronave));
                    _eventBus.Publish(new VueloAsignadoTripulacionQueue(objItinerario.Id, objItinerario.IdTripulacion, objItinerario.IdAeronave));
                    _eventBus.Publish(new VueloAsignadoReservaQueue(objItinerario.Id, objItinerario.IdTripulacion, objItinerario.IdAeronave, detalleVuelo, cantAsientos));
                }
                else
                {
                    await _vueloRepository.UpdateItinerarioAsync(objItinerario);
                }
            }
            //await vueloRepository.CreateAsync(objVuelo);
            //await vueloRepository.UpdateAsync(objVuelo);

            await _unitOfWork.Commit();

            return objVuelo.Id;
        }
    }
}
