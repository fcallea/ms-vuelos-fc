using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Infraestructure.EF.ReadModel
{
    public class AeropuertoReadModel
    {
        public Guid Id { get; set; }
        public string NombreAeropuerto { get; set; }
        public string Localidad { get; set; }
        public string Departamento { get; set; }
        public string OACI { get; set; }
        public string IATA { get; set; }
    }
}
