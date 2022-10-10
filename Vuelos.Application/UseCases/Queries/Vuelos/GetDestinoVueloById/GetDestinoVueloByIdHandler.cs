using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vuelos.Application.Dto.Vuelo;
using Vuelos.Domain.Model.Vuelos;
using Vuelos.Domain.Repositories;

namespace Vuelos.Application.UseCases.Queries.Vuelos.GetDestinoVueloById
{
    public class GetDestinoVueloByIdHandler : IRequestHandler<GetDestinoVueloByIdQuery, DestinoVueloDto>
    {
        private readonly IVueloRepository _destinoVueloRepository;
        private readonly ILogger<GetDestinoVueloByIdQuery> _logger;

        public GetDestinoVueloByIdHandler(IVueloRepository destinoVueloRepository, ILogger<GetDestinoVueloByIdQuery> logger)
        {
            _destinoVueloRepository = destinoVueloRepository;
            _logger = logger;
        }

        public async Task<DestinoVueloDto> Handle(GetDestinoVueloByIdQuery request, CancellationToken cancellationToken)
        {
            DestinoVueloDto result = null;
            try
            {
                Vuelo objdestinoVuelo = await _destinoVueloRepository.FindByIdAsync(request.Id);

                result = new DestinoVueloDto()
                {
                    Id = objdestinoVuelo.Id,
                    IdAeropuertoOrigen = objdestinoVuelo.IdAeropuertoOrigen,
                    IdAeropuertoDestino = objdestinoVuelo.IdAeropuertoDestino
                };
                /*
                foreach (var item in objdestinoVuelo.Detalle)
                {
                    result.Detalle.Add(new DetalledestinoVueloDto()
                    {
                        Cantidad = item.Cantidad,
                        Instrucciones = item.Instrucciones,
                        Precio = item.Precio,
                        ProductoId = item.ProductoId
                    });
                }
                */
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener destinoVuelo con id: { VueloId }", request.Id);
            }

            return result;
        }
    }
}
