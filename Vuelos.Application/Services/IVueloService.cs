using System.Threading.Tasks;

namespace Vuelos.Application.Services
{
    public interface IVueloService
    {
        Task<string> GenerarNroVueloAsync();
    }
}