using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Application.Dto.Aeronave;

namespace Vuelos.Application.UseCases.Queries.Aeronave.GetListarAeronaves
{
    public class GetListarAeronaveQuery : IRequest<List<AeronaveDto>>
    {
        public GetListarAeronaveQuery() { }
    }
}
