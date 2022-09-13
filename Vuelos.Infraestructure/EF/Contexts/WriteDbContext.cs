using Microsoft.EntityFrameworkCore;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Domain.Event;
using Vuelos.Domain.Model.Vuelos;
using Vuelos.Infraestructure.EF.Config.WriteConfig;

namespace Vuelos.Infraestructure.EF.Contexts
{
    public class WriteDbContext : DbContext
    {
        public virtual DbSet<Vuelo> Vuelo { get; set; }
        //public virtual DbSet<ItinerarioVuelo> ItinerarioVuelo { get; set; }
        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var pedidoConfig = new VueloWriteConfig();
            modelBuilder.ApplyConfiguration<Vuelo>(pedidoConfig);
            modelBuilder.ApplyConfiguration<ItinerarioVuelo>(pedidoConfig);

            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<DestinoVueloCreado>();
            modelBuilder.Ignore<VueloAsignado>();
        }
    }
}
