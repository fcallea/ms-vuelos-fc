using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vuelos.Domain.Factories;
using Vuelos.Domain.Repositories;

namespace Vuelos.Application.UseCases.Command.Aeropuertos.RegistrarAeropuerto
{
    public class RegistrarAeropuertoHandler : IRequestHandler<RegistrarAeropuertoCommand, Guid>
    {
        private readonly IAeropuertoRepository aeropuertoRepository;
        private readonly IAeropuertoFactory aeropuertoFactory;
        private readonly IUnitOfWork unitOfWork;

        public RegistrarAeropuertoHandler(
              IUnitOfWork unitOfWork
            , IAeropuertoFactory aeropuertoFactory
            , IAeropuertoRepository aeropuertoRepository
            )
        {
            this.aeropuertoRepository = aeropuertoRepository;
            this.aeropuertoFactory = aeropuertoFactory;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(RegistrarAeropuertoCommand request, CancellationToken cancellationToken)
        {
            var aeropuerto = await aeropuertoRepository.FindByIdAsync(request.IdAeropuerto);

            if (aeropuerto == null)
            {
                Guid IdAeropuerto = request.IdAeropuerto;
                string NombreAeropuerto = request.NombreAeropuerto;
                string Localidad = request.Localidad;
                string Departamento = request.Departamento;
                string OACI = request.OACI;
                string IATA = request.IATA;

                aeropuerto = aeropuertoFactory.RegistrarAeropuerto(IdAeropuerto, NombreAeropuerto, Localidad, Departamento, OACI, IATA);
                await aeropuertoRepository.CreateAsync(aeropuerto);

                await unitOfWork.Commit();
            }
            return aeropuerto.Id;
        }
    }
}
