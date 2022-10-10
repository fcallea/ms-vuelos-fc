using Microsoft.EntityFrameworkCore;
using Vuelos.Domain.Model.Vuelos;
using Vuelos.Infraestructure.EF.Config.WriteConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Domain.Model.Aeropuertos;

namespace Vuelos.Infraestructure.EF.Contexts
{
    public class WriteDbContext : DbContext
    {
        public virtual DbSet<Vuelo> Vuelo { get; set; }
        public virtual DbSet<ItinerarioVuelo> ItinerarioVuelo { get; set; }
        public virtual DbSet<Aeropuerto> Aeropuerto { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var vueloConfig = new VueloWriteConfig();
            modelBuilder.ApplyConfiguration<Vuelo>(vueloConfig);
            modelBuilder.ApplyConfiguration<ItinerarioVuelo>(vueloConfig);

            var aeropuertoConfig = new AeropuertoWriteConfig();
            modelBuilder.ApplyConfiguration<Aeropuerto>(aeropuertoConfig);
        }
    }
}
