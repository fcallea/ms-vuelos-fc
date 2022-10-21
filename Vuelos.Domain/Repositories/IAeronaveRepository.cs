using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Domain.Model.Aeronaves;

namespace Vuelos.Domain.Repositories
{
    public interface IAeronaveRepository
    {
        Task CreateAsync(Aeronave obj);
        Task<Aeronave> FindByIdAsync(Guid id);
        Task UpdateAsync(Aeronave obj);
    }
}
