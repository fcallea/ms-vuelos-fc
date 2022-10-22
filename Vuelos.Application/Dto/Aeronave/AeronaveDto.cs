using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Application.Dto.Aeronave
{
    [ExcludeFromCodeCoverage]
    public class AeronaveDto
    {
        public Guid Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int NroAsientos { get; set; }
        public string EstadoAeronave { get; set; }
        public string Comentario { get; set; }
        public string AeronaveNombre { get; set; }
    }
}
