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

        private AsignarVueloCommand() { }

        public AsignarVueloCommand(VueloDto vuelo)
        {
            IdVuelo = vuelo.IdVuelo; //new Guid("6B49D9BE-56CE-4BDC-B41B-B58970740A3B");
            ListaItinerarios = (List<ItinerarioVueloDto>)vuelo.ListaItinerario;
        }
    }
}
