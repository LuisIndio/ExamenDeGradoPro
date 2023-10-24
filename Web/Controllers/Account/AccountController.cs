using Application.UseCases.Account.Command.CreateAccount;
using Application.UseCases.Account.Queries;
using Application.UseCases.Transaction.Queries;
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

        [Route("search-balance-account")]
        [HttpGet]
        public async Task<IActionResult> SearchBalanceAccount([FromQuery] Guid codigo)
        {
            var query = new GetAmountForAllAccounts
            {
                UserId = codigo 
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Route("search")]
        [HttpGet]
        public async Task<IActionResult> SearchAccount([FromQuery] Guid codigo)
        {
            var query = new GetListAccountQuery
            {
                UserId = codigo
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
