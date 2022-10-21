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

            var itinerario = new ItinerarioVueloDto();

            itinerario.IdTripulacion = IdTripulacion;
            itinerario.IdAeronave = IdAeronave;
            itinerario.ZonaAbordaje = ZonaAbordaje;
            itinerario.FechaHoraAbordaje = FechaHoraAbordaje;
            itinerario.FechaHoraPartida = FechaHoraPartida;
            itinerario.FechaHoraLLegada = FechaHoraLLegada;
            itinerario.NroPuertaAbordaje = NroPuertaAbordaje;
            itinerario.TipoVuelo = TipoVuelo;


            Assert.Equal(IdTripulacion, itinerario.IdTripulacion);
            Assert.Equal(IdAeronave, itinerario.IdAeronave);
            Assert.Equal(NroPuertaAbordaje, itinerario.NroPuertaAbordaje);
            Assert.Equal(TipoVuelo, itinerario.TipoVuelo);
            Assert.Equal(ZonaAbordaje, itinerario.ZonaAbordaje);
        }
    }
}
