using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Application.Services;
using Xunit;

namespace Vuelos.Test.Application.Services
{
    public class VueloService_Tests
    {
        private Guid idAeropuertoOrigen = Guid.NewGuid();
        private Guid idAeropuertoDestino = Guid.NewGuid();
        private Guid gLP = new Guid("B9EF02C0-B11B-4616-963B-67236D597F2C");// --LP
        private Guid gOR = new Guid("CA7FBB54-3020-4705-B28E-F0ED9FAD8F17");// --OR
        private Guid gCB = new Guid("787E2B52-52E3-4BCD-B697-0A3CAC1BCE41");// --CB
        private Guid gSC = new Guid("C5E25DC5-B521-42D7-99AF-559104F15CD7");// --SC

        [Fact]
        public void PruebaServicioVuelo()
        {
            VueloService v = new VueloService();
            Assert.IsType<int>(v.GenerarNroVueloAsync(idAeropuertoOrigen, idAeropuertoDestino));
            Assert.IsType<decimal>(v.CalcularMillasVueloAsync(idAeropuertoOrigen, idAeropuertoDestino));

            Assert.NotNull(v.GenerarNroVueloAsync(gLP, gOR));
            Assert.NotNull(v.GenerarNroVueloAsync(gLP, gCB));
            Assert.NotNull(v.GenerarNroVueloAsync(gLP, gSC));
            Assert.NotNull(v.GenerarNroVueloAsync(gOR, gLP));
            Assert.NotNull(v.GenerarNroVueloAsync(gOR, gCB));
            Assert.NotNull(v.GenerarNroVueloAsync(gOR, gSC));                 
            Assert.NotNull(v.GenerarNroVueloAsync(gCB, gLP));
            Assert.NotNull(v.GenerarNroVueloAsync(gCB, gOR));
            Assert.NotNull(v.GenerarNroVueloAsync(gCB, gSC));                   
            Assert.NotNull(v.GenerarNroVueloAsync(gSC, gLP));
            Assert.NotNull(v.GenerarNroVueloAsync(gSC, gOR));
            Assert.NotNull(v.GenerarNroVueloAsync(gSC, gCB));
                   
            Assert.NotNull(v.CalcularMillasVueloAsync(gLP, gOR));
            Assert.NotNull(v.CalcularMillasVueloAsync(gLP, gCB));
            Assert.NotNull(v.CalcularMillasVueloAsync(gLP, gSC));
                   
            Assert.NotNull(v.CalcularMillasVueloAsync(gOR, gLP));
            Assert.NotNull(v.CalcularMillasVueloAsync(gOR, gCB));
            Assert.NotNull(v.CalcularMillasVueloAsync(gOR, gSC));
                   
            Assert.NotNull(v.CalcularMillasVueloAsync(gCB, gLP));
            Assert.NotNull(v.CalcularMillasVueloAsync(gCB, gOR));
            Assert.NotNull(v.CalcularMillasVueloAsync(gCB, gSC));
                   
            Assert.NotNull(v.CalcularMillasVueloAsync(gSC, gLP));
            Assert.NotNull(v.CalcularMillasVueloAsync(gSC, gOR));
            Assert.NotNull(v.CalcularMillasVueloAsync(gSC, gCB));
        }

        [Theory]
        [InlineData("B9EF02C0-B11B-4616-963B-67236D597F2C", "CA7FBB54-3020-4705-B28E-F0ED9FAD8F17", 10100002, true)]
        [InlineData("B9EF02C0-B11B-4616-963B-67236D597F2C", "787E2B52-52E3-4BCD-B697-0A3CAC1BCE41", 10100004, true)]
        [InlineData("B9EF02C0-B11B-4616-963B-67236D597F2C", "C5E25DC5-B521-42D7-99AF-559104F15CD7", 10100007, true)]
        [InlineData("CA7FBB54-3020-4705-B28E-F0ED9FAD8F17", "B9EF02C0-B11B-4616-963B-67236D597F2C", 10200001, true)]
        [InlineData("CA7FBB54-3020-4705-B28E-F0ED9FAD8F17", "787E2B52-52E3-4BCD-B697-0A3CAC1BCE41", 10200004, true)]
        [InlineData("CA7FBB54-3020-4705-B28E-F0ED9FAD8F17", "C5E25DC5-B521-42D7-99AF-559104F15CD7", 10200007, true)]
        [InlineData("787E2B52-52E3-4BCD-B697-0A3CAC1BCE41", "B9EF02C0-B11B-4616-963B-67236D597F2C", 10400001, true)]
        [InlineData("787E2B52-52E3-4BCD-B697-0A3CAC1BCE41", "CA7FBB54-3020-4705-B28E-F0ED9FAD8F17", 10400002, true)]
        [InlineData("787E2B52-52E3-4BCD-B697-0A3CAC1BCE41", "C5E25DC5-B521-42D7-99AF-559104F15CD7", 10400007, true)]
        [InlineData("C5E25DC5-B521-42D7-99AF-559104F15CD7", "B9EF02C0-B11B-4616-963B-67236D597F2C", 10700001, true)]
        [InlineData("C5E25DC5-B521-42D7-99AF-559104F15CD7", "CA7FBB54-3020-4705-B28E-F0ED9FAD8F17", 10700002, true)]
        [InlineData("C5E25DC5-B521-42D7-99AF-559104F15CD7", "787E2B52-52E3-4BCD-B697-0A3CAC1BCE41", 10700004, true)]
        public async void GenerarNroVuelo_CheckValidData(Guid idAeropuertoOrigen, Guid idAeropuertoDestino, int expectedNroVuelo, bool isEqual)
        {
            var vueloService = new VueloService();
            int nroVuelo = await vueloService.GenerarNroVueloAsync(idAeropuertoOrigen, idAeropuertoDestino);
            if (isEqual)
            {
                Assert.Equal(expectedNroVuelo, nroVuelo);
            }
            else
            {
                Assert.NotEqual(expectedNroVuelo, nroVuelo);
            }
        }


        [Theory]
        [InlineData("B9EF02C0-B11B-4616-963B-67236D597F2C", "CA7FBB54-3020-4705-B28E-F0ED9FAD8F17", 300.00 , false)]
        [InlineData("B9EF02C0-B11B-4616-963B-67236D597F2C", "787E2B52-52E3-4BCD-B697-0A3CAC1BCE41", 300.00 , false)]
        [InlineData("B9EF02C0-B11B-4616-963B-67236D597F2C", "C5E25DC5-B521-42D7-99AF-559104F15CD7", 300.00 , false)]
        [InlineData("CA7FBB54-3020-4705-B28E-F0ED9FAD8F17", "B9EF02C0-B11B-4616-963B-67236D597F2C", 300.00 , false)]
        [InlineData("CA7FBB54-3020-4705-B28E-F0ED9FAD8F17", "787E2B52-52E3-4BCD-B697-0A3CAC1BCE41", 300.00 , false)]
        [InlineData("CA7FBB54-3020-4705-B28E-F0ED9FAD8F17", "C5E25DC5-B521-42D7-99AF-559104F15CD7", 300.00 , false)]
        [InlineData("787E2B52-52E3-4BCD-B697-0A3CAC1BCE41", "B9EF02C0-B11B-4616-963B-67236D597F2C", 300.00 , false)]
        [InlineData("787E2B52-52E3-4BCD-B697-0A3CAC1BCE41", "CA7FBB54-3020-4705-B28E-F0ED9FAD8F17", 300.00 , false)]
        [InlineData("787E2B52-52E3-4BCD-B697-0A3CAC1BCE41", "C5E25DC5-B521-42D7-99AF-559104F15CD7", 300.00 , false)]
        [InlineData("C5E25DC5-B521-42D7-99AF-559104F15CD7", "B9EF02C0-B11B-4616-963B-67236D597F2C", 300.00 , false)]
        [InlineData("C5E25DC5-B521-42D7-99AF-559104F15CD7", "CA7FBB54-3020-4705-B28E-F0ED9FAD8F17", 300.00 , false)]
        [InlineData("C5E25DC5-B521-42D7-99AF-559104F15CD7", "787E2B52-52E3-4BCD-B697-0A3CAC1BCE41", 300.00 , false)]
        public async void CalcularMillasVuelo_CheckValidData(Guid idAeropuertoOrigen, Guid idAeropuertoDestino, decimal expectedMillasVuelo, bool isEqual)
        {
            var vueloService = new VueloService();
            decimal millas = await vueloService.CalcularMillasVueloAsync(idAeropuertoOrigen, idAeropuertoDestino);
            if (isEqual)
            {
                Assert.Equal(expectedMillasVuelo, millas);
            }
            else
            {
                Assert.NotEqual(expectedMillasVuelo, millas);
            }
        }
    }
}
