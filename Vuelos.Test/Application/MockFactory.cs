using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Application.Dto.Vuelo;

namespace Vuelos.Test.Application {
    public class MockFactory {

        public static List<ItinerarioVueloDto> GetListaItinerarios()
        {
            return new List<ItinerarioVueloDto>()
            {
                new()
                {
                    IdTripulacion = Guid.NewGuid(),
                    IdAeronave = Guid.NewGuid(),
                    ZonaAbordaje = "A",
                    NroPuertaAbordaje = "01",
                    FechaHoraAbordaje = DateTime.Now,
                    FechaHoraPartida = DateTime.Now,
                    FechaHoraLLegada = DateTime.Now,
                    TipoVuelo = "COMERCIAL"

                },
                new()
                {
                    IdTripulacion = Guid.NewGuid(),
                    IdAeronave = Guid.NewGuid(),
                    ZonaAbordaje = "A",
                    NroPuertaAbordaje = "01",
                    FechaHoraAbordaje = DateTime.Now,
                    FechaHoraPartida = DateTime.Now,
                    FechaHoraLLegada = DateTime.Now,
                    TipoVuelo = "COMERCIAL"
                },
                new()
                {
                    IdTripulacion = Guid.NewGuid(),
                    IdAeronave = Guid.NewGuid(),
                    ZonaAbordaje = "A",
                    NroPuertaAbordaje = "01",
                    FechaHoraAbordaje = DateTime.Now,
                    FechaHoraPartida = DateTime.Now,
                    FechaHoraLLegada = DateTime.Now,
                    TipoVuelo = "COMERCIAL"
                }
            };
        }
    }
}
