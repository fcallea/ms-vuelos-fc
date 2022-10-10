﻿using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Domain.Model.Vuelos
{
    public class ItinerarioVuelo : Entity<Guid>
    {
        public Guid IdTripulacion { get; private set; }
        public Guid IdAeronave { get; private set; }
        public DateTime FechaHoraCreacion { get; private set; }
        public string ZonaAbordaje { get; private set; }
        public string NroPuertaAbordaje { get; private set; }
        public DateTime? FechaHoraAbordaje { get; private set; }
        public DateTime? FechaHoraPartida { get; private set; }
        public DateTime? FechaHoraLLegada { get; private set; }        
        public int NroAsientosHabilitados { get; private set; }
        public string TipoVuelo { get; private set; }
        public string EstadoItinerarioVuelo { get; private set; }

        private ItinerarioVuelo() { }

        internal ItinerarioVuelo (Guid idTripulacion, Guid idAeronave, string zonaAbordaje, string nroPuertaAbordaje, DateTime fechaHoraAbordaje, DateTime fechaHoraPartida)
        {
            Id = Guid.NewGuid();
            IdTripulacion = idTripulacion;
            IdAeronave = idAeronave;
            FechaHoraCreacion = DateTime.Now;
            ZonaAbordaje = zonaAbordaje;
            NroPuertaAbordaje = nroPuertaAbordaje;
            FechaHoraAbordaje = fechaHoraAbordaje;
            FechaHoraPartida = fechaHoraPartida;
            TipoVuelo = "ESTANDAR";
            EstadoItinerarioVuelo = "";
        }

        internal void ModificarVuelo(Guid idTripulacion, Guid idAeronave, string zonaAbordaje, string nroPuertaAbordaje, DateTime fechaHoraAbordaje, DateTime fechaHoraPartida)
        {
            IdTripulacion = idTripulacion;
            IdAeronave = idAeronave;
            ZonaAbordaje = zonaAbordaje;
            NroPuertaAbordaje = nroPuertaAbordaje;
            FechaHoraAbordaje = fechaHoraAbordaje;
            FechaHoraPartida = fechaHoraPartida;
        }
    }
}