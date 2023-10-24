using Application.UseCases.Transaction.Queries;
using Application.UseCases.Transfer.Command.CreateTransfer;
using Application.UseCases.Transfer.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace Web.Controllers.Transfer
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : Controller
    {
        private readonly IMediator mediator;

        public TransferController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Route("create-transfer")]
        public async Task<IActionResult> CreateTransfer([FromBody] CreateTransferCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [Route("search")]
        [HttpGet]
        public async Task<IActionResult> SearchTransfer([FromQuery] Guid codigo)
        {
            var query = new GetListTransferQuery
            {
                UserId = codigo
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
