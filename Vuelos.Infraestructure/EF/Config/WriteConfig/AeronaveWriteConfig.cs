using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Domain.Model.Aeronaves;

namespace Vuelos.Infraestructure.EF.Config.WriteConfig
{
    public class AeronaveWriteConfig : IEntityTypeConfiguration<Aeronave>
    {
        public void Configure(EntityTypeBuilder<Aeronave> builder)
        {
            builder.ToTable("Aeronave");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NroAsientos)
                .HasColumnName("NroAsientos");

            builder.Property(x => x.EstadoAeronave)
                .HasColumnName("EstadoAeronave")
                .HasMaxLength(20);

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
