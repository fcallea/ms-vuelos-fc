using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vuelos.Application.Dto.Tripulacion;
using Vuelos.Application.UseCases.Command.Tripulaciones.RegistrarTripulacion;
using Vuelos.Application.UseCases.Queries.Tripulacion.GetListarTripulacion;

namespace Vuelos.WebApi.Controllers
{
    [Route("api/Tripulacion")]
    [ApiController]
    public class TripulacionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TripulacionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("RegistrarTripulacion")]
        public async Task<IActionResult> GuardarTripulacion([FromBody] RegistrarTripulacionCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }

        [HttpGet("ListarTripulacion")]
        public async Task<ActionResult<List<TripulacionDto>>> ListarTripulacion()
        {
            return await _mediator.Send(new GetListarTripulacionQuery());
        }
    }
}
