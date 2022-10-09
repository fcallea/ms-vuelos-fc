using System;
using System.Threading.Tasks;

namespace Vuelos.Application.Services
{
    public interface IVueloService
    {
        Task<decimal> CalcularMillasVueloAsync(Guid idAeropuertoOrigen, Guid idAeropuertoDestino);
        Task<int> GenerarNroVueloAsync(Guid idAeropuertoOrigen, Guid idAeropuertoDestino);
    }
}