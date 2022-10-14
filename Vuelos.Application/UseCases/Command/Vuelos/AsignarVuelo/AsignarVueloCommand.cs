using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Application.Dto.Vuelo;

namespace Vuelos.Application.UseCases.Command.Vuelos.AsignarVuelo
{
    public class AsignarVueloCommand : IRequest<Guid>
    {
        public Guid IdVuelo { get; set; }
        public List<ItinerarioVueloDto> ListaItinerarios { get; set; }

        public AsignarVueloCommand() { }

        public AsignarVueloCommand(Guid idVuelo, List<ItinerarioVueloDto> listaItinerarios)
        {
            IdVuelo = idVuelo;
            ListaItinerarios = listaItinerarios;
        }
    }
}
