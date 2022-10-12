﻿using MediatR;
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
            VueloDto result = null;
            try
            {
                Vuelo objVuelo = await vueloRepository.FindByIdAsync(request.IdVuelo);

                result = new VueloDto()
                {
                    IdVuelo = objVuelo.Id,
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
                _logger.LogError(ex, "Error al obtener destinoVuelo con id: { VueloId }", request.IdVuelo);
            }
            return result.IdVuelo;
        }
    }
}