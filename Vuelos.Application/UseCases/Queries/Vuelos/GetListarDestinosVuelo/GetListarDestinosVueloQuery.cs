using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Application.Dto.Vuelo;

namespace Vuelos.Application.UseCases.Queries.Vuelos.GetListarDestinosVuelo
{
    public class GetListarDestinosVueloQuery : IRequest<List<DestinoVueloDto>>
    {
        public GetListarDestinosVueloQuery() { }
    }
}
