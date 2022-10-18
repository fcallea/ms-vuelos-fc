using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Infraestructure.EF.ReadModel
{
    public class TripulacionReadModel
    {
        public Guid Id { get; set; }
        public string EstadoTripulacion { get; set; }
    }
}
