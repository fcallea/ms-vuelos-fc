using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vuelos.Application.Dto.Vuelo;
using Vuelos.Domain.Model.Aeropuertos;
using Vuelos.Domain.Repositories;

namespace Vuelos.Application.UseCases.Queries.Vuelos.GetListarDestinosVuelo
{
    [ExcludeFromCodeCoverage]
    public class GetListarDestinosVueloHandler : IRequestHandler<GetListarDestinosVueloQuery, List<DestinoVueloDto>>
    {
        private readonly IVueloRepository _destinosVueloRepository;
        private readonly IAeropuertoRepository _aeropuertoRepository;

        public GetListarDestinosVueloHandler(IVueloRepository destinoVueloRepository, IAeropuertoRepository aeropuertoRepository)
        {
            _destinosVueloRepository = destinoVueloRepository;
            _aeropuertoRepository = aeropuertoRepository;
        }

        public async Task<List<DestinoVueloDto>> Handle(GetListarDestinosVueloQuery request, CancellationToken cancellationToken)
        {
            var DestinosVuelo = await _destinosVueloRepository.getDestinosVueloActiva();
            var DestVueloDto = new List<DestinoVueloDto>();
            foreach (var objDestVuelos in DestinosVuelo)
            {
                Aeropuerto aeropuertoOrigen = await _aeropuertoRepository.FindByIdAsync(objDestVuelos.IdAeropuertoOrigen);
                Aeropuerto aeropuertoDestino = await _aeropuertoRepository.FindByIdAsync(objDestVuelos.IdAeropuertoDestino);

                var objtTripulacionDto = new DestinoVueloDto()
                {
                    Id = objDestVuelos.Id,
                    IdAeropuertoOrigen = objDestVuelos.IdAeropuertoOrigen,
                    NombreAeropuertoOrigen = aeropuertoOrigen.NombreAeropuerto,
                    DepartamentoOrigen = aeropuertoOrigen.Departamento,
                    IdAeropuertoDestino = objDestVuelos.IdAeropuertoDestino,
                    NombreAeropuertoDestino = aeropuertoDestino.NombreAeropuerto,
                    DepartamentoDestino = aeropuertoDestino.Departamento,
                    DestinoVueloNombre = aeropuertoOrigen.Departamento + " ("+ aeropuertoOrigen.IATA + ")"+ " - "+ aeropuertoDestino.Departamento + " (" + aeropuertoDestino.IATA + ")"
                };
                DestVueloDto.Add(objtTripulacionDto);
            }
            return DestVueloDto;
        }
    }
}
