using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Application.Dto.Tripulacion
{
    [ExcludeFromCodeCoverage]
    public class TripulacionDto
    {
        public Guid TripulacionGuid { get; set; }
        public int TripulacionId { get; set; }
        public string TripulacionNombre { get; set; }
        public int TripulacionEstado { get; set; }

    }
}
