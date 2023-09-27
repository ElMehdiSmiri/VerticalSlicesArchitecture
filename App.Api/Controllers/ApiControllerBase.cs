using App.Api.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [ApiController]
    [ApiExceptionFilter]
    [Route("Api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender? _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        protected ActionResult IdMismatchBadRequest()
        {
            var errorResponse = new
            {
                type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                title = "Bad Request",
                status = 400,
                traceId = HttpContext.TraceIdentifier,
                message = "The path Id does not match the Dto Id"
            };

            return BadRequest(errorResponse);
        }
    }
}
