using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Application.Dto.Vuelo;

namespace Vuelos.Application.UseCases.Queries.Vuelos.GetDestinoVueloById
{
    [ExcludeFromCodeCoverage]
    public class GetDestinoVueloByIdQuery : IRequest<DestinoVueloDto>
    {
        public Guid Id { get; set; }

        public GetDestinoVueloByIdQuery(Guid id)
        {
            Id = id;
        }

        public GetDestinoVueloByIdQuery() { }
    }
}
