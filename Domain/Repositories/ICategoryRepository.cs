using Domain.Model;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category, Guid>
    {
        Task CreateAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Guid categoryId);
    }
}
