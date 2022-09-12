using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vuelos.Application.Services;
using Vuelos.Domain.Factories;
using Vuelos.Domain.Model.Vuelos;
using Vuelos.Domain.Repositories;

namespace Vuelos.Application.UseCases.Command.Vuelos.CrearDestinoVuelo
{
    public class CrearDestinoVueloHandler : IRequestHandler<CrearDestinoVueloCommand, Guid>
    {
        private readonly IVueloRepository _vueloRepository;
        private readonly ILogger<CrearDestinoVueloHandler> _logger;
        private readonly IVueloService _vueloService;
        private readonly IVueloFactory _vueloFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearDestinoVueloHandler(IVueloRepository vueloRepository, ILogger<CrearDestinoVueloHandler> logger,
            IVueloService vueloService, IVueloFactory vueloFactory, IUnitOfWork unitOfWork)
        {
            _vueloRepository = vueloRepository;
            _logger = logger;
            _vueloService = vueloService;
            _vueloFactory = vueloFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearDestinoVueloCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string nroVuelo = await _vueloService.GenerarNroVueloAsync();
                Vuelo objDestinoVuelo = _vueloFactory.Create(request.IdAeropuertoOrigen, request.IdAeropuertoDestino, nroVuelo);

                objDestinoVuelo.ConsolidarPedido();
                return objDestinoVuelo.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear pedido");
            }
            return Guid.Empty;
        }
    }
}
