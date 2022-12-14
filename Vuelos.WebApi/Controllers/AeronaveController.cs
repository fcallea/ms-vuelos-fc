using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vuelos.Application.Dto.Aeronave;
using Vuelos.Application.UseCases.Command.Aeronaves.RegistrarAeronave;
using Vuelos.Application.UseCases.Queries.Aeronave.GetListarAeronaves;

namespace Vuelos.WebApi.Controllers
{
    [Route("apiVuelo/Aeronave")]
    [ApiController]
    public class AeronaveController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AeronaveController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("RegistrarAeronave")]
        public async Task<IActionResult> GuardarAeronave([FromBody] RegistrarAeronaveCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }

        [HttpGet("ListarAeronaves")]
        public async Task<ActionResult<List<AeronaveDto>>> ListarAeronaves()
        {
            return await _mediator.Send(new GetListarAeronaveQuery());
        }
    }
}
