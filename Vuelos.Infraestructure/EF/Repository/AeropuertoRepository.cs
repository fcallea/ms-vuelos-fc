using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Domain.Model.Aeropuertos;
using Vuelos.Domain.Repositories;
using Vuelos.Infraestructure.EF.Contexts;

namespace Aeropuertos.Infraestructure.EF.Repository
{
    public class AeropuertoRepository : IAeropuertoRepository
    {
        public readonly DbSet<Aeropuerto> _aeropuertos;

        public AeropuertoRepository(WriteDbContext context)
        {
            _aeropuertos = context.Aeropuerto;
        }

        public async Task CreateAsync(Aeropuerto obj)
        {
            await _aeropuertos.AddAsync(obj);
        }

        public async Task<Aeropuerto> FindByIdAsync(Guid id)
        {
            return await _aeropuertos.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Aeropuerto> FindByIdDestinoAeropuertoAsync(Guid id)
        {
            return await _aeropuertos.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Aeropuerto obj)
        {
            _aeropuertos.Update(obj);

            return Task.CompletedTask;
        }
    }
}
