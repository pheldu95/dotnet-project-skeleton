using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private IMediator? _mediator; //naming convention for private properties to start with an _

        protected IMediator Mediator => //can use this Mediator property in other api controllers that derive from this BaseApiController class
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>()
                ?? throw new InvalidOperationException("IMediator service is unavailable"); //if GetService returns null, then error thrown
    }
}