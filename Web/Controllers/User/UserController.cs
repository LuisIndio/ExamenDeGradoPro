using Application.UseCases.User.Command.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMediator mediator;
        
        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Route("Register")]
        public async Task<IActionResult> RegisterUser(RegisterUserCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
