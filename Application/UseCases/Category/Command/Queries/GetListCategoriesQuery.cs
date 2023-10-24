using Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Category.Command.Queries
{
    public class GetListCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
        public Guid UserId { get; set; }
    }
}
