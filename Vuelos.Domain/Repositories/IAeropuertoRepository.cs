using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Domain.Model.Aeropuertos;

namespace Vuelos.Domain.Repositories
{
    public interface IAeropuertoRepository
    {
        Task CreateAsync(Aeropuerto obj);
        Task<Aeropuerto> FindByIdAsync(Guid id);
    }
}
