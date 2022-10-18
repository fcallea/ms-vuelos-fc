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
    public class AeronaveReadConfig : IEntityTypeConfiguration<AeronaveReadModel>
    {
        public void Configure(EntityTypeBuilder<AeronaveReadModel> builder)
        {
            builder.ToTable("Aeronave");
            builder.HasKey(x => x.Id);

            builder.Property<int>(x => x.NroAsientos)
                .HasColumnName("NroAsientos")
                .HasColumnType("int");

            builder.Property<string>(x => x.EstadoAeronave)
                .HasColumnName("EstadoAeronave")
                .HasColumnType("nvarchar(20)")
                .HasMaxLength(120);   
        }
    }
}
