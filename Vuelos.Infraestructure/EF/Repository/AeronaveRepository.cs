using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Domain.Model.Aeronaves;
using Vuelos.Domain.Repositories;
using Vuelos.Infraestructure.EF.Contexts;

namespace Vuelos.Infraestructure.EF.Repository
{
    public class AeronaveRepository : IAeronaveRepository
    {
        public readonly DbSet<Aeronave> _aeronave;

        public AeronaveRepository(WriteDbContext context)
        {
            _aeronave = context.Aeronave;
        }

        public async Task CreateAsync(Aeronave obj)
        {
            await _aeronave.AddAsync(obj);
        }

        public async Task<Aeronave> FindByIdAsync(Guid id)
        {
            return await _aeronave.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Aeronave obj)
        {
            _aeronave.Update(obj);
            return Task.CompletedTask;
        }
        public async Task<ICollection<Aeronave>> getAeronaveActiva()
        {
            var pedidoList = await _aeronave
                            .AsNoTracking()
                            //.Where(x => x.EstadoTripulacion.Contains("ACTIVO"))
                            .ToListAsync();
            return pedidoList;
        }
    }
}
