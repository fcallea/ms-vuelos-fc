using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Domain.Model.Vuelos;

namespace Vuelos.Domain.Repositories
{
    public interface IVueloRepository : IRepository<Vuelo, Guid>
    {
        Task<Vuelo> FindByIdVueloAsync(Guid id);
        Task<Vuelo> FindByIdVueloPorDestinoAsync(Guid idAeropuertoOrigen, Guid idAeropuertoDestino);
        Task SaveItinerarioAsync(ItinerarioVuelo iti);
        Task UpdateItinerarioAsync(ItinerarioVuelo iti);
        Task UpdateAsync(Vuelo obj);
    }
}
