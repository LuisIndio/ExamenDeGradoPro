using Domain.Factories;
using Domain.Repositories;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.User.Command.LoginUser
{
    internal class LoginUserHandler : IRequestHandler<LoginUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserFactory _userFact;
        private readonly IUnitOfWork _unitOfWork;

        public LoginUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork,IUserFactory userFactory)
        {
            _userRepository = userRepository;
            _userFact = userFactory;
            _unitOfWork = unitOfWork;
        }

        public Task<Guid> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
