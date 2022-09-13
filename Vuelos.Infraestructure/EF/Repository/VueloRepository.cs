using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Domain.Model.Vuelos;
using Vuelos.Domain.Repositories;
using Vuelos.Infraestructure.EF.Contexts;

namespace Vuelos.Infraestructure.EF.Repository
{
    public class VueloRepository : IVueloRepository
    {
        public readonly DbSet<Vuelo> _vuelos;
        public VueloRepository(WriteDbContext context)
        {
            _vuelos = context.Vuelo;
        }

        public async Task CreateAsync(Vuelo obj)
        {
            await _vuelos.AddAsync(obj);
        }

        public async Task<Vuelo> FindByIdAsync(Guid id)
        {
            return await _vuelos.Include("_listaItinerariosVuelo")
                .SingleAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Vuelo obj)
        {
            _vuelos.Update(obj);

            return Task.CompletedTask;
        }
    }
}
