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
    public class VueloReadConfig : IEntityTypeConfiguration<VueloReadModel>, IEntityTypeConfiguration<ItinerarioVueloReadModel>
    {
        public void Configure(EntityTypeBuilder<VueloReadModel> builder)
        {
            builder.ToTable("Vuelo");
            builder.HasKey(x => x.Id);

            builder.Property<Guid>(x => x.IdAeropuertoOrigen)
                .HasColumnName("IdAeropuertoOrigen")
                .HasColumnType("uniqueidentifier");

            builder.Property<Guid>(x => x.IdAeropuertoDestino)
                .HasColumnName("IdAeropuertoDestino")
                .HasColumnType("uniqueidentifier");

            builder.Property<int>(x => x.NroVuelo)
                .HasColumnName("NroVuelo")
                .HasColumnType("int");

            builder.Property<string>(x => x.EstadoVuelo)
                .HasColumnName("EstadoVuelo")
                .HasColumnType("nvarchar(20)")
                .HasMaxLength(20);

            builder.Property<decimal>(x => x.MillasVuelo)
                .HasColumnName("MillasVuelo")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.HasMany(x => x.ItinerarioVuelo)
                .WithOne(x => x.Vuelo);
        }

        public void Configure(EntityTypeBuilder<ItinerarioVueloReadModel> builder)
        {
            builder.ToTable("ItinerarioVuelo");
            builder.HasKey(x => x.Id);

            builder.Property<Guid>(x => x.IdTripulacion)
                .HasColumnName("IdTripulacion")
                .HasColumnType("uniqueidentifier");

            builder.Property<Guid>(x => x.IdAeronave)
                .HasColumnName("IdAeronave")
                .HasColumnType("uniqueidentifier");

            builder.Property<Guid>(x => x.IdVuelo)
                .HasColumnName("IdVuelo")
                .HasMaxLength(40);

            builder.Property<DateTime>(x => x.FechaHoraCreacion)
                .HasColumnName("FechaHoraCreacion")
                .HasColumnType("DateTime");

            builder.Property<string>(x => x.ZonaAbordaje)
                .HasColumnName("ZonaAbordaje")
                .HasColumnType("nvarchar(20)")
                .HasMaxLength(20);

            builder.Property<string>(x => x.NroPuertaAbordaje)
                .HasColumnName("NroPuertaAbordaje")
                .HasColumnType("nvarchar(20)")
                .HasMaxLength(20);

            builder.Property<DateTime>(x => x.FechaHoraAbordaje)
                .HasColumnName("FechaHoraAbordaje")
                .HasColumnType("DateTime");

            builder.Property(x => x.FechaHoraPartida)
                .HasColumnName("FechaHoraPartida")
                .HasColumnType("datetime");

            builder.Property<int>(x => x.NroAsientosHabilitados)
                .HasColumnName("NroAsientosHabilitados")
                .HasColumnType("int");

            builder.Property<string>(x => x.TipoVuelo)
                .HasColumnName("TipoVuelo")
                .HasColumnType("nvarchar(20)")
                .HasMaxLength(20);

            builder.Property<string>(x => x.EstadoItinerarioVuelo)
                .HasColumnName("EstadoItinerarioVuelo")
                .HasColumnType("nvarchar(20)")
                .HasMaxLength(20);

        }
    }
}
