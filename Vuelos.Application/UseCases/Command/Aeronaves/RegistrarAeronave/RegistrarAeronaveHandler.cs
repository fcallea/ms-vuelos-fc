using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vuelos.Domain.Factories;
using Vuelos.Domain.Repositories;

namespace Vuelos.Application.UseCases.Command.Aeronaves.RegistrarAeronave
{
    public class RegistrarAeronaveHandler : IRequestHandler<RegistrarAeronaveCommand, Guid>
    {
        private readonly IAeronaveRepository _aeronaveRepository;
        private readonly IAeronaveFactory _aeronaveFactory;
        private readonly IUnitOfWork _unitOfWork;

        public RegistrarAeronaveHandler(
              IUnitOfWork unitOfWork
            , IAeronaveFactory aeronaveFactory
            , IAeronaveRepository aeronaveRepository
            )
        {
            _aeronaveRepository = aeronaveRepository;
            _aeronaveFactory = aeronaveFactory;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(RegistrarAeronaveCommand request, CancellationToken cancellationToken)
        {
            var aeronave = await _aeronaveRepository.FindByIdAsync(request.Id);

            if (aeronave == null)
            {
                Guid IdAeronave = request.Id;
                int NroAsientos = request.NroAsientos;
                string EstadoAeronave = request.EstadoAeronave;
                string Marca = request.Marca;
                string Modelo = request.Modelo;
                string Comentario = request.Comentario;

                aeronave = _aeronaveFactory.RegistrarAeronave(IdAeronave, NroAsientos, EstadoAeronave, Marca, Modelo, Comentario);
                await _aeronaveRepository.CreateAsync(aeronave);

                await _unitOfWork.Commit();
            }
            return aeronave.Id;
        }
    }
}
