using Application.UseCases.Account.Command.CreateAccount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Route("create-account")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
