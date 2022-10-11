using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vuelos.Application.UseCases.Command.Aeropuertos.RegistrarAeropuerto;

namespace Vuelos.WebApi.Controllers
{
    [Route("api/Aeropuerto")]
    [ApiController]
    public class AeropuertoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AeropuertoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegistrarAeropuertoCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }
    }
}
