using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Domain.Model.Aeronaves;

namespace Vuelos.Domain.Factories
{
    public interface IAeronaveFactory
    {
        Aeronave RegistrarAeronave(Guid IdAeronave, int NroAsientos, string EstadoAeronave, string Marca, string Modelo, string Comentario);
    }
}
