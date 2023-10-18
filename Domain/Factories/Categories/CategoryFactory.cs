using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.Categories
{
    public class CategoryFactory : ICategoryFactory
    {
        public Category CreateCategory(Guid userId, string name, string description)
        {
            return new Category(userId,name, description);
        }
    }
   
}
