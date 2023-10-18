using Domain.Model;
using Domain.Repositories;
using Infrastructure.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Repository
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly WriteDbContext _writeDbContext;

        public CategoryRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
        }
        public async Task CreateAsync(Category category)
        {
            await _writeDbContext.Categories.AddAsync(category);
        }

        public async Task DeleteAsync(Guid categoryId)
        {
            var category = _writeDbContext.Categories.Find(categoryId);
            _writeDbContext.Remove(category);
            await _writeDbContext.SaveChangesAsync();
        }

        public Task<Category?> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Category category)
        {
            _writeDbContext.Categories.Update(category);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
