using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Application.Dto.Vuelo;
using Xunit;

namespace Vuelos.Test.Application.Dto
{
    public class VueloDto_Tests
    {
        [Fact]
        public void VueloDto_CheckPropertiesValid()
        {
            var Id = Guid.NewGuid();
            var ListaItinerario = new List<ItinerarioVueloDto>();

            var vuelo = new VueloDto();
            vuelo.Id = Id;
            vuelo.ListaItinerario = ListaItinerario;

            Assert.Equal(Id, vuelo.Id);
            Assert.Equal(ListaItinerario, vuelo.ListaItinerario);
        }
    }
}
