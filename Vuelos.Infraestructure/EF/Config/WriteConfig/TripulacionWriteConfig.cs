using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Domain.Model.Tripulaciones;

namespace Vuelos.Infraestructure.EF.Config.WriteConfig
{
    public class TripulacionWriteConfig : IEntityTypeConfiguration<Tripulacion>
    {
        public void Configure(EntityTypeBuilder<Tripulacion> builder)
        {
            builder.ToTable("Tripulacion");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TripulacionNombre)
                .HasColumnName("TripulacionNombre")
                .HasMaxLength(20);

            builder.Property(x => x.EstadoTripulacion)
                .HasColumnName("EstadoTripulacion")
                .HasMaxLength(20);

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
