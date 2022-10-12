using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Application.Dto.Vuelo
{
    public class ItinerarioVueloDto
    {
        public Guid IdTripulacion { get; private set; }
        public Guid IdAeronave { get; private set; }
        public string ZonaAbordaje { get; private set; }
        public string NroPuertaAbordaje { get; private set; }
        public DateTime? FechaHoraAbordaje { get; private set; }
        public DateTime? FechaHoraPartida { get; private set; }
        public DateTime? FechaHoraLLegada { get; private set; }
        public string TipoVuelo { get; private set; }
    }
}
