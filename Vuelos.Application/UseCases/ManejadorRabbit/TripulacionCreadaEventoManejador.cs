using Newtonsoft.Json;
using Shared.Rabbitmq.BusRabbit;
using Shared.Rabbitmq.EventoQueue;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Application.UseCases.ManejadorRabbit
{
    public class TripulacionCreadaEventoManejador : IEventoManejador<TripulacionEventoQueue>
    {
        public Task Handle(TripulacionEventoQueue evento)
        {
            var url = "https://localhost:44365/api/Tripulacion/RegistrarTripulacion";
            //var url = "https://aeronlineaserviciosapivuelos.azurewebsites.net/api/Vuelo/GuardarTripulacion";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.Method = "POST";
            request.Timeout = 300000;
            var json = JsonConvert.SerializeObject(evento);

            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] bytes = encoding.GetBytes(json);

            Stream newStream = request.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();

            // Invocación del servicio y respuesta con las facturas generadas
            var response = request.GetResponse();

            return Task.CompletedTask;
        }
    }
}
