using App.Application.Features.CityFeatures.Commands;
using App.Application.Features.CityFeatures.Dtos;
using App.Application.Features.CityFeatures.Queries;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("Api/countries/{countryId}/[controller]")]
    public class CitiesController : ApiControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<CityDto>>> Get([FromRoute] Guid countryId)
        {
            return Ok(await Mediator.Send(new GetCitiesByCountryIdQuery(countryId)));
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CityDto>> Get([FromRoute] Guid countryId, Guid id)
        {
            return Ok(await Mediator.Send(new GetCityByIdQuery(countryId, id)));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromRoute] Guid countryId, [FromBody] CreateCityCommand command)
        {
            if (command.CountryId != countryId)
            {
                return IdMismatchBadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Guid>> Put([FromRoute] Guid countryId, Guid id, [FromBody] EditCityCommand command)
        {
            if (command.CountryId != countryId || command.Id != id)
            {
                return IdMismatchBadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete([FromRoute] Guid countryId, Guid id)
        {
            return Ok(await Mediator.Send(new DeleteCityCommand(countryId, id)));
        }
    }
}
