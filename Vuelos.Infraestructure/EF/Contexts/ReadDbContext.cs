using Microsoft.EntityFrameworkCore;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Domain.Event;
using Vuelos.Infraestructure.EF.Config.ReadConfig;
using Vuelos.Infraestructure.EF.ReadModel;

namespace Vuelos.Infraestructure.EF.Contexts
{
    public class ReadDbContext : DbContext
    {
        public virtual DbSet<VueloReadModel> Vuelo { get; set; }
        //public virtual DbSet<ItinerarioVueloReadModel> ItinerarioVuelo { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var vueloConfig = new VueloReadConfig();
            modelBuilder.ApplyConfiguration<VueloReadModel>(vueloConfig);
            modelBuilder.ApplyConfiguration<ItinerarioVueloReadModel>(vueloConfig);

            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<DestinoVueloCreado>();
            modelBuilder.Ignore<VueloAsignado>();
        }
    }
}
