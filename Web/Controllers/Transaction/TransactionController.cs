using Application.UseCases.Transaction.Command.CreateTransaction;
using Application.UseCases.Transaction.Command.DeleteTransaction;
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
                UserSearchIdList = codigo 
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Route("search-date")]
        [HttpGet]
        public async Task<IActionResult> SearchTransactionDate([FromQuery] Guid codigo, [FromQuery] int year, [FromQuery] int month)
        {
            var query = new GetListTransactionDateQuery
            {
                UserSearchIdList = codigo, // Asumiendo que codigo es el identificador de usuario que deseas buscar.
                Year = year, // Añadimos el año desde la solicitud.
                Month = month, // Añadimos el mes desde la solicitud.
            };

            try
            {
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error al buscar transacciones: " + ex.Message);
            }
        }

        [Route("search-all")]
        [HttpGet]
        public async Task<IActionResult> SearchTransactionAll([FromQuery] Guid codigo, [FromQuery] Guid category, [FromQuery] Guid account)
        {
            var query = new GetListTransactionForAll
            {
                UserId = codigo,
                CategoryId = category,
                AccountId = account
            };

            try
            {
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error al buscar transacciones: " + ex.Message);
            }
        }

        [Route("delete-transaction")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTransaction([FromBody] DeleteTransactionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


    }
}
