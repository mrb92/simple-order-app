using MediatR;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace SimpleOrderApp.WebApi.Base
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator = null;

        /// <summary>
        /// the mediator instance to use to emit queries and command in Web API controllers
        /// </summary>
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
