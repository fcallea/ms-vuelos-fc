using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vuelos.Application.Dto.Tripulacion;
using Vuelos.Domain.Repositories;

namespace Vuelos.Application.UseCases.Queries.Tripulacion.GetListarTripulacion
{
    [ExcludeFromCodeCoverage]
    public class GetListarTripulacionByIdHandler : IRequestHandler<GetListarTripulacionQuery, List<TripulacionDto>>
    {
        private readonly ITripulacionRepository _tripulacionRepository;

        public GetListarTripulacionByIdHandler(ITripulacionRepository tripulacionRepository)
        {
            _tripulacionRepository = tripulacionRepository;
        }

        public async Task<List<TripulacionDto>> Handle(GetListarTripulacionQuery request, CancellationToken cancellationToken)
        {
            var Tripulaciones = await _tripulacionRepository.getTripulacionActiva();
            var TripDto = new List<TripulacionDto>(); 
            foreach (var objTripulacion in Tripulaciones)
            {
                int auxEstTrip = 0;
                if (objTripulacion.EstadoTripulacion == "ACTIVO")
                    auxEstTrip = 1;
                var objtTripulacionDto = new TripulacionDto()
                {
                    TripulacionGuid = objTripulacion.Id,
                    TripulacionNombre = objTripulacion.TripulacionNombre,
                    TripulacionEstado = auxEstTrip
                };
                TripDto.Add(objtTripulacionDto);
            }
            return TripDto;
        }
    }
}
