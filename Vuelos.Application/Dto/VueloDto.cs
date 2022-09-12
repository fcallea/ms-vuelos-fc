using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Application.Dto
{
    public class VueloDto
    {
        public Guid IdAeropuertoOrigen { get; set; }
        public Guid IdAeropuertoDestino { get; set; }
        public int NroVuelo { get; set; }
        public ICollection<ItinerarioVueloDto> ListaItinerariosVuelo { get; set; }

        public VueloDto()
        {
            ListaItinerariosVuelo = new List<ItinerarioVueloDto>();
        }
    }
}
