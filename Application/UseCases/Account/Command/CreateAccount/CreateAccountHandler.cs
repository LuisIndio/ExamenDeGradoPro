using Domain.Factories.Accounts;
using Domain.Repositories;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Account.Command.CreateAccount
{
    internal class CreateAccountHandler : IRequestHandler<CreateAccountCommand, Guid>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountFactory _accountFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAccountHandler(IAccountRepository accountRepository, IAccountFactory accountFactory, IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _accountFactory = accountFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = _accountFactory.CreateAccount(request.Name, request.Balance);

            await _accountRepository.CreateAsync(account);
            await _unitOfWork.Commit();
            return account.Id;
        }
    }
}
