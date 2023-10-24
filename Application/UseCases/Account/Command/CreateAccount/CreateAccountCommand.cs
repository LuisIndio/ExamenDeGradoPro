using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Account.Command.CreateAccount
{
    public class CreateAccountCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public CreateAccountCommand(Guid userId, string name, decimal balance)
        {
            UserId = userId;
            Name = name;
            Balance = balance;
        }
    }
}
