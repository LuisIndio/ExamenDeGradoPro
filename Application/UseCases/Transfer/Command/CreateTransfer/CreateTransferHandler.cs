using Domain.Factories.Transfers;
using Domain.Repositories;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Transfer.Command.CreateTransfer
{
    internal class CreateTransferHandler : IRequestHandler<CreateTransferCommand, Guid>
    {
        private readonly ITransferFactory _transferFactory;
        private readonly ITransferRepository _transferRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTransferHandler(ITransferFactory transferFactory, ITransferRepository transferRepository, IUnitOfWork unitOfWork)
        {
            _transferFactory = transferFactory;
            _transferRepository = transferRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            var transfer = _transferFactory.CreateTransfer(request.Date, request.Amount, request.AccountId, request.AccountId2, request.UserId);
            await _transferRepository.CreateAsync(transfer);
            await _unitOfWork.Commit();
            return transfer.Id;
        }
    }
}
