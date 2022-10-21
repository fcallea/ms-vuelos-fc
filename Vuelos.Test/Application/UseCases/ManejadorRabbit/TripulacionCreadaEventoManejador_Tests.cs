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
    public class TripulacionCreadaEventoManejador_Tests
    {
        [Fact]
        public void validacionEventoManejador()
        {
            var e = new TripulacionEventoQueue(Guid.Empty, 0, "", 0);

            e.TripulacionGuid = Guid.Empty;
            e.TripulacionId = 0;
            e.TripulacionNombre = "";
            e.TripulacionEstado = 0;

            var V = new TripulacionCreadaEventoManejador();
            Assert.NotNull(V.Handle(e));
            Assert.True(V != null);
        }
    }
}
