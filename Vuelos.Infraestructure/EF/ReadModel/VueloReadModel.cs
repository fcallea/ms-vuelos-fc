using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Infraestructure.EF.ReadModel
{
    public class VueloReadModel
    {
        public Guid Id { get; set; }
        public Guid IdAeropuertoOrigen { get; set; }
        public Guid IdAeropuertoDestino { get; set; }
        public int NroVuelo { get; set; }
        public string EstadoVuelo { get; set; }
        public decimal MillasVuelo { get; set; }

        public ICollection<ItinerarioVueloReadModel> ItinerarioVuelo { get; set; }
    }
}
