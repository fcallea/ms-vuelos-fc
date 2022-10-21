using Shared.Rabbitmq.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Rabbitmq.EventoQueue
{
    public class AeronaveAgregadaEventoQueuePrueba : Evento
    {
       
        public Guid Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        
        public int NroAsientos { get; set; }
        public string EstadoAeronave { get; set; }
        public string Comentario { get; set; }

        public AeronaveAgregadaEventoQueuePrueba(Guid id, string marca, string modelo, int nroAsientos, string estadoAeronave, string comentario)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            NroAsientos = nroAsientos;
            EstadoAeronave = estadoAeronave;            
            Comentario = comentario;
        }
    }
}
