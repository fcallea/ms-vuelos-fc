using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Infraestructure.EF.ReadModel
{
    public class AeronaveReadModel
    {
        public Guid Id { get; set; }
        public int NroAsientos { get; set; }
        public string EstadoAeronave { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Comentario { get; set; }

    }
}
