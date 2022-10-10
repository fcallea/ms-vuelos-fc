using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Application.Dto.Vuelo
{
    public class DestinoVueloDto
    {
        public Guid Id { get; set; }
        public Guid IdAeropuertoOrigen { get; set; }
        public Guid IdAeropuertoDestino { get; set; }
    }
}
