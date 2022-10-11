using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vuelos.Application;
using Vuelos.Domain.Repositories;
using Vuelos.Infraestructure.EF;
using Vuelos.Infraestructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Infraestructure.EF.Repository;
using Aeropuertos.Infraestructure.EF.Repository;

namespace Vuelos.Infraestructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddApplication();

            var connectionString = configuration.GetConnectionString("ConexionDB");

            services.AddDbContext<ReadDbContext>(context =>
                context.UseSqlServer(connectionString));
            services.AddDbContext<WriteDbContext>(context =>
                context.UseSqlServer(connectionString));


            services.AddScoped<IVueloRepository, VueloRepository>();
            services.AddScoped<IAeropuertoRepository, AeropuertoRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }

    }
}
