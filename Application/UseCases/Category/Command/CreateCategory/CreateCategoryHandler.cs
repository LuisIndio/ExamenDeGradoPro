using Domain.Factories.Categories;
using Domain.Repositories;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Category.Command.CreateCategory
{
    internal class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryFactory _categoryFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryHandler(ICategoryRepository categoryRepository, ICategoryFactory categoryFactory, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _categoryFactory = categoryFactory;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _categoryFactory.CreateCategory(request.Name, request.Description);

            await _categoryRepository.CreateAsync(category);
            await _unitOfWork.Commit();
            return category.Id;
        }
    }
     
}
