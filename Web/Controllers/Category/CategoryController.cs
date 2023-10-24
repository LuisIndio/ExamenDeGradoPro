using Application.UseCases.Category.Command.CreateCategory;
using Application.UseCases.Category.Command.Queries;
using Application.UseCases.Transaction.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Category
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Route("create-category")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Route("search")]
        [HttpGet]
        public async Task<IActionResult> SearchCategory([FromQuery] Guid codigo)
        {
            var query = new GetListCategoriesQuery
            {
                UserId = codigo
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
