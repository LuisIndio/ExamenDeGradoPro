using Application.Dto;
using Application.UseCases.Category.Command.Queries;
using Infrastructure.EF.Context;
using Infrastructure.EF.ReadModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries.Category
{
    internal class GetListCategoriesHandler : IRequestHandler<GetListCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly DbSet<CategoryReadModel> categories;

        public GetListCategoriesHandler(ReadDbContext context)
        {
            categories = context.Categories;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetListCategoriesQuery request, CancellationToken cancellationToken)
        {
            var query = categories.AsNoTracking().AsQueryable();

            if (request.UserId != Guid.Empty)
            {
                query = query.Where(x => x.UserId == request.UserId);
            }
            var lista = await query.Select(x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                UserId = x.UserId
            }).ToListAsync();

            return lista;
        }
    }
}
