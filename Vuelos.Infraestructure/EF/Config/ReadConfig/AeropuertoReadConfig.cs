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
    public class AeropuertoReadConfig : IEntityTypeConfiguration<AeropuertoReadModel>
    {
        public void Configure(EntityTypeBuilder<AeropuertoReadModel> builder)
        {
            builder.ToTable("Aeropuerto");
            builder.HasKey(x => x.Id);

            builder.Property<string>("NombreAeropuerto")
                .HasColumnType("nvarchar(120)")
                .HasMaxLength(120);

            builder.Property<string>("Localidad")
                .HasColumnType("nvarchar(120)")
                .HasMaxLength(120);

            builder.Property<string>("Departamento")
                .HasColumnType("nvarchar(120)")
                .HasMaxLength(120);

            builder.Property<string>("OACI")
                .HasColumnType("nvarchar(4)")
                .HasMaxLength(4);

            builder.Property<string>("IATA")
                .HasColumnType("nvarchar(3)")
                .HasMaxLength(3);
        }
    }
}
