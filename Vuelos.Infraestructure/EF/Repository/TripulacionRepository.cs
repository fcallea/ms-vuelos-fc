using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Domain.Model.Tripulaciones;
using Vuelos.Domain.Repositories;
using Vuelos.Infraestructure.EF.Contexts;

namespace Vuelos.Infraestructure.EF.Repository
{
    public class TripulacionRepository : ITripulacionRepository
    {
        public readonly DbSet<Tripulacion> _tripulacion;

        public TripulacionRepository(WriteDbContext context)
        {
            _tripulacion = context.Tripulacion;
        }

        public async Task CreateAsync(Tripulacion obj)
        {
            await _tripulacion.AddAsync(obj);
        }

        public async Task<Tripulacion> FindByIdAsync(Guid id)
        {
            return await _tripulacion.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Tripulacion obj)
        {
            _tripulacion.Update(obj);
            return Task.CompletedTask;
        }

        public async Task<ICollection<Tripulacion>> getTripulacionActiva()
        {
            var pedidoList = await _tripulacion
                            .AsNoTracking()
                            .Where(x => x.EstadoTripulacion.Contains("ACTIVO"))
                            .ToListAsync();        
            return pedidoList;
        }

    }
}
