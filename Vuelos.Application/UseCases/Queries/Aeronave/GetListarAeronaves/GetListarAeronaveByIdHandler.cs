using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vuelos.Application.Dto.Aeronave;
using Vuelos.Domain.Repositories;

namespace Vuelos.Application.UseCases.Queries.Aeronave.GetListarAeronaves
{
    public class GetListarAeronaveByIdHandler : IRequestHandler<GetListarAeronaveQuery, List<AeronaveDto>>
    {
        private readonly IAeronaveRepository _aeronaveRepository;

        public GetListarAeronaveByIdHandler(IAeronaveRepository aeronaveRepository)
        {
            _aeronaveRepository = aeronaveRepository;
        }

        public async Task<List<AeronaveDto>> Handle(GetListarAeronaveQuery request, CancellationToken cancellationToken)
        {
            var Aeronaves = await _aeronaveRepository.getAeronaveActiva();
            var AeroDto = new List<AeronaveDto>();
            foreach (var objAeronave in Aeronaves)
            {
                var objtAeronaveDto = new AeronaveDto()
                {
                    Id = objAeronave.Id,
                    Marca = objAeronave.Marca,
                    Modelo = objAeronave.Modelo,
                    NroAsientos = objAeronave.NroAsientos,
                    EstadoAeronave = objAeronave.EstadoAeronave,
                    Comentario = objAeronave.Comentario,
                    AeronaveNombre = objAeronave.Marca+"-"+objAeronave.Modelo
                };
                AeroDto.Add(objtAeronaveDto);
            }
            return AeroDto;
        }
    }
}
