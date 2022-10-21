using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Vuelos.Application.UseCases.ManejadorRabbit;
using Shared.Rabbitmq.EventoQueue;

namespace Vuelos.Test.Application.UseCases.ManejadorRabbit
{
    public class AeronaveAgregadaEventoManejador_Tests
    {
        [Fact]
        public void validacionEventoManejador()
        {
            var e = new AeronaveAgregadaEventoQueue(Guid.Empty, "", "", 0, "", "");

            e.Id = Guid.Empty;
            e.Marca = "";
            e.Modelo = "";
            e.NroAsientos = 30;
            e.EstadoAeronave = "";
            e.Comentario = "";

            var V = new AeronaveAgregadaEventoManejador();
            Task t = V.Handle(e);
            Assert.NotNull(V);
            Assert.True(V != null);
            Assert.NotNull(t);
        }
    }
}
