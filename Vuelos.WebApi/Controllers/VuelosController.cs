using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vuelos.Application.Dto.Vuelo;
using Vuelos.Application.UseCases.Command.Aeronaves.RegistrarAeronave;
using Vuelos.Application.UseCases.Command.Tripulaciones.RegistrarTripulacion;
using Vuelos.Application.UseCases.Command.Vuelos.AsignarVuelo;
using Vuelos.Application.UseCases.Command.Vuelos.CrearDestinoVuelo;
using Vuelos.Application.UseCases.Queries.Vuelos.GetDestinoVueloById;
using Vuelos.Application.UseCases.Queries.Vuelos.GetListarDestinosVuelo;

namespace Vuelos.WebApi.Controllers
{
    [Route("apiVuelo/Vuelo")]
    [ApiController]
    public class VuelosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VuelosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListarDestinosVuelo")]
        public async Task<ActionResult<List<DestinoVueloDto>>> ListarDestinosVuelo()
        {
            return await _mediator.Send(new GetListarDestinosVueloQuery());
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


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearDestinoVueloCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }

        [Route("AsignarVuelo")]
        [HttpPost]
        public async Task<IActionResult> AsignarVuelo([FromBody] AsignarVueloCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }



/*
        [HttpPost("RegistrarTripulacion")]
        public async Task<IActionResult> GuardarTripulacion([FromBody] RegistrarTripulacionCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }


        [HttpPost("RegistrarAeronave")]
        public async Task<IActionResult> GuardarAeronave([FromBody] RegistrarAeronaveCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }
*/
    }
}
