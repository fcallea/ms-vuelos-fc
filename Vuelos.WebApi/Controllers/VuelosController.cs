using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Vuelos.Application.Dto.Vuelo;
using Vuelos.Application.UseCases.Command.Vuelos.CrearVuelo;
using Vuelos.Application.UseCases.Queries.Vuelos.GetDestinoVueloById;

namespace Vuelos.WebApi.Controllers
{
    [Route("api/Vuelo")]
    [ApiController]
    public class VuelosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VuelosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearDestinoVueloCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }

        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetPedidoById([FromRoute] GetDestinoVueloByIdQuery command)
        {
            DestinoVueloDto result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
