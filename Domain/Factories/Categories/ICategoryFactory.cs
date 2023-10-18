using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.Categories
{
    public interface ICategoryFactory
    {
        Category CreateCategory(Guid userId, string name, string description);
    }
}
