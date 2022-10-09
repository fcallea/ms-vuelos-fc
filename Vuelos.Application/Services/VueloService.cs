using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Application.Services
{
    public class VueloService : IVueloService
    {
        public Task<int> GenerarNroVueloAsync(Guid idAeropuertoOrigen, Guid idAeropuertoDestino)
        {

            Guid gLP = new Guid("B9EF02C0-B11B-4616-963B-67236D597F2C");// --LP
            Guid gOR = new Guid("CA7FBB54-3020-4705-B28E-F0ED9FAD8F17");// --OR
            Guid gCB = new Guid("787E2B52-52E3-4BCD-B697-0A3CAC1BCE41");// --CB
            Guid gSC = new Guid("C5E25DC5-B521-42D7-99AF-559104F15CD7");// --SC

            int nroVuelo = 0;

            switch (idAeropuertoOrigen)
            {
                case var g when (g == gLP): 
                    switch (idAeropuertoDestino)
                    {
                        case var x when (x == gOR):
                            nroVuelo = 10100002;
                            break;
                        case var x when (x == gCB):
                            nroVuelo = 10100004;
                            break;
                        case var x when (x == gSC):
                            nroVuelo = 10100007;
                            break;
                    };
                    break;
                case var g when (g == gOR):
                    switch (idAeropuertoDestino)
                    {
                        case var x when (x == gLP):
                            nroVuelo = 10200001;
                            break;
                        case var x when (x == gCB):
                            nroVuelo = 10200004;
                            break;
                        case var x when (x == gSC):
                            nroVuelo = 10200007;
                            break;
                    };
                    break;
                case var g when (g == gCB):
                    switch (idAeropuertoDestino)
                    {
                        case var x when (x == gLP):
                            nroVuelo = 10400001;
                            break;
                        case var x when (x == gOR):
                            nroVuelo = 10400002;
                            break;
                        case var x when (x == gSC):
                            nroVuelo = 10400007;
                            break;
                    };
                    break;
                case var g when (g == gSC):
                    switch (idAeropuertoDestino)
                    {
                        case var x when (x == gLP):
                            nroVuelo = 10700001;
                            break;
                        case var x when (x == gOR):
                            nroVuelo = 10700002;
                            break;
                        case var x when (x == gCB):
                            nroVuelo = 10700004;
                            break;
                    };
                    break;
            }
            return Task.FromResult(nroVuelo);
        }

        public Task<decimal> CalcularMillasVueloAsync(Guid idAeropuertoOrigen, Guid idAeropuertoDestino)
        {

            Guid gLP = new Guid("B9EF02C0-B11B-4616-963B-67236D597F2C");// --LP
            Guid gOR = new Guid("CA7FBB54-3020-4705-B28E-F0ED9FAD8F17");// --OR
            Guid gCB = new Guid("787E2B52-52E3-4BCD-B697-0A3CAC1BCE41");// --CB
            Guid gSC = new Guid("C5E25DC5-B521-42D7-99AF-559104F15CD7");// --SC

            decimal millasVuelo = 0.0m;

            switch (idAeropuertoOrigen)
            {
                case var g when (g == gLP):
                    switch (idAeropuertoDestino)
                    {
                        case var x when (x == gOR):
                            millasVuelo = 196.0m;
                            break;
                        case var x when (x == gCB):
                            millasVuelo = 234.0m;
                            break;
                        case var x when (x == gSC):
                            millasVuelo = 548.0m;
                            break;
                    };
                    break;
                case var g when (g == gOR):
                    switch (idAeropuertoDestino)
                    {
                        case var x when (x == gLP):
                            millasVuelo = 196.0m;
                            break;
                        case var x when (x == gCB):
                            millasVuelo = 124.0m;
                            break;
                        case var x when (x == gSC):
                            millasVuelo = 421.0m;
                            break;
                    };
                    break;
                case var g when (g == gCB):
                    switch (idAeropuertoDestino)
                    {
                        case var x when (x == gLP):
                            millasVuelo = 234.0m;
                            break;
                        case var x when (x == gOR):
                            millasVuelo = 124.0m;
                            break;
                        case var x when (x == gSC):
                            millasVuelo = 319.0m;
                            break;
                    };
                    break;
                case var g when (g == gSC):
                    switch (idAeropuertoDestino)
                    {
                        case var x when (x == gLP):
                            millasVuelo = 548.0m;
                            break;
                        case var x when (x == gOR):
                            millasVuelo = 421.0m;
                            break;
                        case var x when (x == gCB):
                            millasVuelo = 319.0m;
                            break;
                    };
                    break;
            }
            return Task.FromResult(millasVuelo);
        }
    }
}

