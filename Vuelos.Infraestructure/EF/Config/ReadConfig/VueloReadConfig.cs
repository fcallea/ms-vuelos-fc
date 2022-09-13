using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Infraestructure.EF.ReadModel;

namespace Vuelos.Infraestructure.EF.Config.ReadConfig
{
    class VueloReadConfig : IEntityTypeConfiguration<VueloReadModel>, IEntityTypeConfiguration<ItinerarioVueloReadModel>
    {
        public void Configure(EntityTypeBuilder<VueloReadModel> builder)
        {
            builder.ToTable("Vuelo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdAeropuertoOrigen)
                .HasColumnName("IdAeropuertoOrigen")
                .HasMaxLength(40);

            builder.Property(x => x.IdAeropuertoDestino)
                .HasColumnName("IdAeropuertoDestino")
                .HasMaxLength(40); 

            builder.Property(x => x.NroVuelo)
                .HasColumnName("NroVuelo")
                .HasMaxLength(8);

            builder.Property(x => x.EstadoVuelo)
                .HasColumnName("EstadoVuelo")
                .HasMaxLength(20);

            builder.Property(x => x.MillasVuelo)
                .HasColumnName("MillasVuelo")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.HasMany(x => x.Itinerario)
                .WithOne(x => x.Vuelo);
        }

        public void Configure(EntityTypeBuilder<ItinerarioVueloReadModel> builder)
        {
            builder.ToTable("ItinerarioVuelo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdTripulacion)
                .HasColumnName("IdTripulacion")
                .HasMaxLength(40);

            builder.Property(x => x.IdAeronave)
                .HasColumnName("IdAeronave")
                .HasMaxLength(40);

            builder.Property(x => x.IdVuelo)
                .HasColumnName("IdVuelo")
                .HasMaxLength(40);

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
        }
    }
}
