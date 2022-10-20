using Shared.Rabbitmq.EventoQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Application.UseCases.ManejadorRabbit;
using Xunit;

namespace Vuelos.Test.Application.UseCases.ManejadorRabbit
{
    public class AeropuertoCreadoEventoManejador_Tests
    {
        [Fact]
        public void validacionEventoManejador()
        {
            var e = new AeropuertoCreadoQueue(Guid.Empty, "", "", "", "", "");

            e.IdAeropuerto = Guid.Empty;
            e.NombreAeropuerto = "";
            e.OACI = "";
            e.IATA = "";
            e.Localidad = "";
            e.EstadoAeropuerto = "";

            var V = new AeropuertoCreadoEventoManejador();
            Assert.NotNull(V.Handle(e));
            Assert.True(V != null);
        }
    }
}
