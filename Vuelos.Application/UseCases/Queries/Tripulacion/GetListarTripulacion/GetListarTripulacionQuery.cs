using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Application.Dto.Tripulacion;

namespace Vuelos.Application.UseCases.Queries.Tripulacion.GetListarTripulacion
{
    public class GetListarTripulacionQuery : IRequest<List<TripulacionDto>>
    {
        public GetListarTripulacionQuery() { }
    }
}
