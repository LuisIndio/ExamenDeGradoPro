﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Account.Command.CreateAccount
{
    public class CreateAccountCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Balance { get; set; }

        public CreateAccountCommand(string name, string balance)
        {
            Name = name;
            Balance = balance;
        }
    }
}