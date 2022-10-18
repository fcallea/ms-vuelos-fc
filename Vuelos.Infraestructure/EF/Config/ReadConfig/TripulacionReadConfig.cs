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
    public class TripulacionReadConfig : IEntityTypeConfiguration<TripulacionReadModel>
    { 
        public void Configure(EntityTypeBuilder<TripulacionReadModel> builder)
        {
            builder.ToTable("Tripulacion");
            builder.HasKey(x => x.Id);

            builder.Property<string>(x => x.EstadoTripulacion)
                .HasColumnName("EstadoTripulacion")
                .HasColumnType("nvarchar(20)")
                .HasMaxLength(120);   
        }
    }
}
