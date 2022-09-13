using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Domain.Model.Vuelos;

namespace Vuelos.Infraestructure.EF.Config.WriteConfig
{
    public class VueloWriteConfig : IEntityTypeConfiguration<Vuelo>,
        IEntityTypeConfiguration<ItinerarioVuelo>
    {
        public void Configure(EntityTypeBuilder<Vuelo> builder)
        {
            builder.ToTable("Vuelo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdAeropuertoOrigen)
                  .HasColumnName("IdAeropuertoOrigen");

            builder.Property(x => x.IdAeropuertoDestino)
                .HasColumnName("IdAeropuertoDestino");

            builder.Property(x => x.NroVuelo)
                .HasColumnName("NroVuelo")
                .HasMaxLength(20);

            builder.Property(x => x.EstadoVuelo)
                .HasColumnName("EstadoVuelo")
                .HasMaxLength(20);

            builder.Property(x => x.MillasVuelo)
                .HasColumnName("MillasVuelo")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.HasMany(typeof(ItinerarioVuelo), "_listaItinerariosVuelo");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
            builder.Ignore(x => x.ListaItinerariosVuelo);
        }

        public void Configure(EntityTypeBuilder<ItinerarioVuelo> builder)
        {
            builder.ToTable("ItinerarioVuelo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdTripulacion)
                .HasColumnName("IdTripulacion");

            builder.Property(x => x.IdAeronave)
                .HasColumnName("IdAeronave");

            builder.Property(x => x.IdVuelo)
                .HasColumnName("IdVuelo");

            builder.Property(x => x.FechaHoraCreacion)
                .HasColumnName("FechaHoraCreacion")
                .HasColumnType("datetime");

            builder.Property(x => x.ZonaAbordaje)
                .HasColumnName("ZonaAbordaje")
                .HasMaxLength(20);

            builder.Property(x => x.NroPuertaAbordaje)
                .HasColumnName("NroPuertaAbordaje")
                .HasMaxLength(20);

            builder.Property(x => x.FechaHoraAbordaje)
                .HasColumnName("FechaHoraAbordaje")
                .HasColumnType("datetime");

            builder.Property(x => x.FechaHoraPartida)
                .HasColumnName("FechaHoraPartida")
                .HasColumnType("datetime");

            builder.Property(x => x.NroAsientosHabilitados)
                .HasColumnName("NroAsientosHabilitados");

            builder.Property(x => x.TipoVuelo)
                .HasColumnName("TipoVuelo")
                .HasMaxLength(20);

            builder.Property(x => x.EstadoItinerarioVuelo)
                .HasColumnName("EstadoItinerarioVuelo");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
