using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Application.UseCases.Command.Aeronaves.RegistrarAeronave
{
   public class RegistrarAeronaveCommand : IRequest<Guid>
    {
        public Guid Id { get; private set; }
        public int NroAsientos { get; private set; }
        public string EstadoAeronave { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Comentario { get; private set; }

        private RegistrarAeronaveCommand()
        {
        }
        public RegistrarAeronaveCommand(Guid id, int nroAsientos, string estadoAeronave, string marca, string modelo, string comentario)
        {
            Id = id;
            NroAsientos = nroAsientos;
            EstadoAeronave = estadoAeronave;
            Marca = marca;
            Modelo = modelo;
            Comentario = comentario;
        }
    }
}
