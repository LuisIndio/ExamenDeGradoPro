﻿using Domain.Factories;
using Domain.Repositories;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.User.Command.RegisterUser
{
    internal class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly IUserFactory _userFactory;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserHandler(IUserFactory userFactory, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userFactory = userFactory;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userFactory.RegisterUser(request.Name, request.Email, request.Password);
            //user.AddCategory(user.Id,"alimentos","esta categoria es para los alimentos");
            //user.AddAccount(user.Id,"colchon",120);
            await _userRepository.CreateAsync(user);
            await _unitOfWork.Commit();
            return user.Id;
        }
    }
}
