using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Application.Dto.Vuelo
{
    public class VueloDto
    {
        public Guid Id { get; set; }
        public ICollection<ItinerarioVueloDto> ListaItinerario { get; set; }        
    }
}
