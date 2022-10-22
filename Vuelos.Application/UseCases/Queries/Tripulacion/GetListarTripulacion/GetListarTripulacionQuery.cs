using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Application.Dto.Tripulacion;

namespace Vuelos.Application.UseCases.Queries.Tripulacion.GetListarTripulacion
{
    [ExcludeFromCodeCoverage]
    public class GetListarTripulacionQuery : IRequest<List<TripulacionDto>>
    {
        public GetListarTripulacionQuery() { }
    }
}
