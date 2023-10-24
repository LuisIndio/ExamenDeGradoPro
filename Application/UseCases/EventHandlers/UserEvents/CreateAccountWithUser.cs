using Domain.events;
using Domain.Factories.Accounts;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.EventHandlers.UserEvents
{
    public class CreateAccountWithUser : INotificationHandler<UserCreated>
    {
        private readonly IAccountFactory _accountFactory;
        private readonly IAccountRepository _accountRepository;

        public CreateAccountWithUser(IAccountFactory accountFactory, IAccountRepository accountRepository)
        {
           _accountFactory = accountFactory;
            _accountRepository = accountRepository;
        }
        public async Task Handle(UserCreated notification, CancellationToken cancellationToken)
        {
            var account = _accountFactory.CreateAccount(userId : notification.UserId, name : "Cuenta de Ahorros",balance:  0);
            await _accountRepository.CreateAsync(account);
        }
    }
}
