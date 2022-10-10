using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Domain.Model.Aeropuertos;

namespace Vuelos.Infraestructure.EF.Config.WriteConfig
{
    public class AeropuertoWriteConfig : IEntityTypeConfiguration<Aeropuerto>
    {
        public void Configure(EntityTypeBuilder<Aeropuerto> builder)
        {
            builder.ToTable("Aeropuerto");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NombreAeropuerto)
                .HasColumnName("NombreAeropuerto");

            builder.Property(x => x.Localidad)
                .HasColumnName("Localidad");

            builder.Property(x => x.Departamento)
                .HasColumnName("Departamento"); ;

            builder.Property(x => x.OACI)
                .HasColumnName("OACI");

            builder.Property(x => x.IATA)
                .HasColumnName("IATA");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
