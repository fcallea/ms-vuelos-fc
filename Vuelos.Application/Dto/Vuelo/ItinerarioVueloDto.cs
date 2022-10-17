using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Application.Dto.Vuelo
{
    public class ItinerarioVueloDto
    {
        public Guid IdTripulacion { get; set; }
        public Guid IdAeronave { get; set; }
        public string ZonaAbordaje { get; set; }
        public string NroPuertaAbordaje { get; set; }
        public DateTime FechaHoraAbordaje { get; set; }
        public DateTime FechaHoraPartida { get; set; }
        public DateTime FechaHoraLLegada { get; set; }
        public string TipoVuelo { get; set; }
        public string EsNuevo { get; set; }
    }
}
