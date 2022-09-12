using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Application.UseCases.Command.Vuelos.CrearDestinoVuelo
{
    public class CrearDestinoVueloCommand : IRequest<Guid>
    {
        public Guid IdAeropuertoOrigen { get; set; }
        public Guid IdAeropuertoDestino { get; set; }

        private CrearDestinoVueloCommand()
        {
        }
        public CrearDestinoVueloCommand(Guid idAeropuertoOrigen, Guid idAeropuertoDestino)
        {
            IdAeropuertoOrigen = idAeropuertoOrigen;
            IdAeropuertoDestino = idAeropuertoDestino;
        }
    }
}
