using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Infraestructure.EF.ReadModel
{
    public class ItinerarioVueloReadModel
    {
        public Guid Id { get; set; }
        public Guid IdTripulacion { get; set; }
        public Guid IdAeronave { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public string ZonaAbordaje { get; set; }
        public string NroPuertaAbordaje { get; set; }
        public DateTime FechaHoraAbordaje { get; set; }
        public DateTime FechaHoraPartida { get; set; }
        public DateTime FechaHoraLLegada { get; set; }
        public int NroAsientosHabilitados { get; set; }
        public string TipoVuelo { get; set; }
        public string EstadoItinerarioVuelo { get; set; }
        public VueloReadModel Vuelo { get; set; }
    }
}
