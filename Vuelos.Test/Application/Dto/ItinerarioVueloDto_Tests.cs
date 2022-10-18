using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Application.Dto.Vuelo;
using Xunit;

namespace Vuelos.Test.Application.Dto {
    public class ItinerarioVueloDto_Tests {
        [Fact]
        public void ItinerarioDto_CheckPropertiesValid() {
            Guid IdTripulacion = Guid.NewGuid();
            Guid IdAeronave = Guid.NewGuid();
            var ZonaAbordaje = "A";
            var NroPuertaAbordaje = "01";
            var FechaHoraAbordaje = DateTime.Now;;
            var FechaHoraPartida = DateTime.Now;
            var FechaHoraLLegada = DateTime.Now;
            var TipoVuelo = "COMERCIAL";
            var EsNuevo = true;

            var itinerario = new ItinerarioVueloDto();

            Assert.Equal(Guid.Empty, itinerario.IdTripulacion);
            Assert.Equal(Guid.Empty, itinerario.IdAeronave);
            Assert.NotNull((object)itinerario.FechaHoraAbordaje);
            Assert.NotNull((object)itinerario.FechaHoraPartida);
            Assert.NotNull((object)itinerario.FechaHoraLLegada);

            itinerario.IdTripulacion = IdTripulacion;
            itinerario.IdAeronave = IdAeronave;
            itinerario.FechaHoraAbordaje = FechaHoraAbordaje;
            itinerario.FechaHoraPartida = FechaHoraPartida;
            itinerario.FechaHoraLLegada = FechaHoraLLegada;

            Assert.Equal(IdTripulacion, itinerario.IdTripulacion);
            Assert.Equal(IdAeronave, itinerario.IdAeronave);
            Assert.NotNull((object)FechaHoraAbordaje);
            Assert.NotNull((object)FechaHoraPartida);
            Assert.NotNull((object)FechaHoraLLegada);
        }
    }
}
