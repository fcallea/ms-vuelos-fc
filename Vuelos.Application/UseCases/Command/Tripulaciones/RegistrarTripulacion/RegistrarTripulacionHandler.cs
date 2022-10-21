using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vuelos.Domain.Factories;
using Vuelos.Domain.Repositories;

namespace Vuelos.Application.UseCases.Command.Tripulaciones.RegistrarTripulacion
{
    public class RegistrarTripulacionHandler : IRequestHandler<RegistrarTripulacionCommand, Guid>
    {
        private readonly ITripulacionRepository _tripulacionRepository;
        private readonly ITripulacionFactory _tripulacionFactory;
        private readonly IUnitOfWork _unitOfWork;

        public RegistrarTripulacionHandler(
              IUnitOfWork unitOfWork
            , ITripulacionFactory TripulacionFactory
            , ITripulacionRepository TripulacionRepository
            )
        {
            _tripulacionRepository = TripulacionRepository;
            _tripulacionFactory = TripulacionFactory;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(RegistrarTripulacionCommand request, CancellationToken cancellationToken)
        {
            var Tripulacion = await _tripulacionRepository.FindByIdAsync(request.Id);

            if (Tripulacion == null)
            {
                Guid IdTripulacion = request.Id;
                string TripulacionNombre = request.TripulacionNombre;
                string EstadoTripulacion = "ACTIVO";//request.EstadoTripulacion;

                Tripulacion = _tripulacionFactory.RegistrarTripulacion(IdTripulacion, TripulacionNombre, EstadoTripulacion);
                await _tripulacionRepository.CreateAsync(Tripulacion);

                await _unitOfWork.Commit();
            }
            return Tripulacion.Id;
        }
    }
}
