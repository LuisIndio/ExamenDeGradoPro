﻿using Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.User.Command.RegisterUser
{
    public record RegisterUserCommand : IRequest<Guid>
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public RegisterUserCommand(string name,string email,string password) 
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
