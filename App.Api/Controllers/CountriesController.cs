using App.Application.Features.CountryFeatures.Commands;
using App.Application.Features.CountryFeatures.Dtos;
using App.Application.Features.CountryFeatures.Queries;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    public class CountriesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<CountryDto>>> Get()
        {
            return Ok(await Mediator.Send(new GetCountriesQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<CountryDto>>> Get([FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new GetCoutryByIdQuery(id)));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] CreateCountryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(Guid id, [FromBody] EditCountryCommand command)
        {
            if (id != command.Id)
            {
                return IdMismatchBadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteCountryCommand(id));

            return NoContent();
        }
    }
}
