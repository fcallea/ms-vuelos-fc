using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Domain.Model.Tripulaciones;

namespace Vuelos.Domain.Repositories
{
    public interface ITripulacionRepository
    {
        Task CreateAsync(Tripulacion obj);
        Task<Tripulacion> FindByIdAsync(Guid id);
        Task<ICollection<Tripulacion>> getTripulacionActiva();
        Task UpdateAsync(Tripulacion obj);
    }
}
