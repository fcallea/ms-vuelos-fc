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
        public readonly DbSet<ItinerarioVuelo> _itinerario;
        private WriteDbContext _wdbcontext;

        public VueloRepository(WriteDbContext context)
        {
            _vuelos = context.Vuelo;
            _wdbcontext = context;
            _itinerario = context.ItinerarioVuelo;
        }

        public async Task CreateAsync(Vuelo obj)
        {
            await _vuelos.AddAsync(obj);
        }

        public async Task<Vuelo> FindByIdAsync(Guid id)
        {
            return await _vuelos
                .Include("_listaItinerariosVuelo")
                .SingleAsync(x => x.Id == id);
        }

        public async Task<Vuelo> FindByIdVueloAsync(Guid id)
        {
            return await _vuelos
                .Include("_listaItinerariosVuelo")
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Vuelo> FindByIdVueloPorDestinoAsync(Guid idAeropuertoOrigen, Guid idAeropuertoDestino)
        {
            string miEstadoActivo = "ACTIVO";
            return await _vuelos.SingleOrDefaultAsync(x => x.IdAeropuertoOrigen == idAeropuertoOrigen && x.IdAeropuertoDestino == idAeropuertoDestino);
        }

        public Task UpdateAsync(Vuelo obj)
        {
            _vuelos.Update(obj);
            return Task.CompletedTask;
        }

        public Task SaveItinerarioAsync(ItinerarioVuelo iti)
        {    
            _itinerario.AddAsync(iti);
            return Task.CompletedTask;
        }
        public Task UpdateItinerarioAsync(ItinerarioVuelo iti)
        {
            _itinerario.Update(iti);
            return Task.CompletedTask;
        }
        public async Task<ICollection<Vuelo>> getDestinosVueloActiva()
        {
            var vueloList = await _vuelos
                            .AsNoTracking()
                            //.Where(x => x.EstadoTripulacion.Contains("ACTIVO"))
                            .ToListAsync();
            return vueloList;
        }
    }
}
