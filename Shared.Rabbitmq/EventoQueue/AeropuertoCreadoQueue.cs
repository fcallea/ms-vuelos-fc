using Shared.Rabbitmq.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Rabbitmq.EventoQueue
{
    public class AeropuertoCreadoQueue : Evento
    {
        public Guid IdAeropuerto { get; set; }
        public string NombreAeropuerto { get; set; }
        public string OACI { get; set; }
        public string IATA { get; set; }
        public string Localidad { get; set; }
        public string EstadoAeropuerto { get; set; }

        public AeropuertoCreadoQueue(Guid idAeropuerto, string nombreAeropuerto, string sOACI, string sIATA, string localidad, string estadoAeropuerto)
        {
            IdAeropuerto = idAeropuerto;
            NombreAeropuerto = nombreAeropuerto;
            OACI = sOACI;
            IATA = sIATA;
            Localidad = localidad;
            EstadoAeropuerto = estadoAeropuerto;
        }
    }
}
