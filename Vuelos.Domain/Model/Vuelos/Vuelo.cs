using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Domain.Event;

namespace Vuelos.Domain.Model.Vuelos
{
    public class Vuelo : AggregateRoot<Guid>
    {
        public Guid IdAeropuertoOrigen { get; private set; }
        public Guid IdAeropuertoDestino { get; private set; }
        public int NroVuelo { get; private set; }
        public string EstadoVuelo { get; private set; }
        public decimal MillasVuelo { get; private set; }

        private readonly ICollection<ItinerarioVuelo> _listaItinerariosVuelo;

        public IReadOnlyCollection<ItinerarioVuelo> ListaItinerariosVuelo
        {
            get
            {
                return new ReadOnlyCollection<ItinerarioVuelo>(_listaItinerariosVuelo.ToList());
            }
        }

        private Vuelo() { }

        internal Vuelo(Guid idAeropuertoOrigen, Guid idAeropuertoDestino, int nroVuelo, decimal millasVuelo)
        {
            Id = Guid.NewGuid();
            IdAeropuertoOrigen = idAeropuertoOrigen;
            IdAeropuertoDestino = idAeropuertoDestino;
            NroVuelo = nroVuelo;
            EstadoVuelo = "ACTIVO";
            MillasVuelo = millasVuelo;
            _listaItinerariosVuelo = new List<ItinerarioVuelo>();
        }

        public void AgregarItinerarioVuelo(Guid idTripulacion, Guid idAeronave, string zonaAbordaje, string nroPuertaAbordaje, DateTime fechaHoraAbordaje, DateTime fechaHoraPartida)
        {
            var itinerarioVuelo = _listaItinerariosVuelo.FirstOrDefault(x => x.IdTripulacion == idTripulacion && x.IdAeronave == idAeronave && x.FechaHoraPartida == fechaHoraPartida);
            if (itinerarioVuelo == null)
            {
                itinerarioVuelo = new ItinerarioVuelo(idTripulacion, idAeronave, zonaAbordaje, nroPuertaAbordaje, fechaHoraAbordaje, fechaHoraPartida);
                _listaItinerariosVuelo.Add(itinerarioVuelo);
            }
            else
            {
                itinerarioVuelo.ModificarVuelo(idTripulacion, idAeronave, zonaAbordaje, nroPuertaAbordaje, fechaHoraAbordaje, fechaHoraPartida);
            }
            AddDomainEvent(new VueloAsignado(Id, itinerarioVuelo.Id, idTripulacion, idAeronave));
        }

        public void ConsolidarDestinoVuelo()
        {
            var evento = new DestinoVueloCreado(Id, IdAeropuertoOrigen, IdAeropuertoDestino);
            AddDomainEvent(evento);
        }
    }
}
