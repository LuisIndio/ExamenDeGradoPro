using Application.UseCases.Transaction.Command.CreateTransaction;
using Application.UseCases.Transaction.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Transaction
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Route("create-transaction")]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
            
        }
        [Route("search")]
        [HttpGet]
        public async Task<IActionResult> SearchTransaction([FromQuery] Guid codigo)
        {
            var query = new GetListTransactionQuery
            {
                UserSearchIdList = codigo // Asumiendo que HabitacionId es el nombre del campo que quieres buscar en la consulta.
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}
