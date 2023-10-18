using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Category.Command.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public CreateCategoryCommand(Guid userId, string name, string description)
        {
            UserId = userId;
            Name = name;
            Description = description;
        }
    }
}
