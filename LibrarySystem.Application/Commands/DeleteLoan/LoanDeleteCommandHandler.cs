using Azure.Core;
using Dapper;
using LibrarySystem.Core.Repositories;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.DeleteLoan;

public class LoanDeleteCommandHandler : IRequestHandler<LoanDeleteCommand, Unit>
{
    private readonly ILoanRepository _loanRepository;

    public LoanDeleteCommandHandler(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<Unit> Handle(LoanDeleteCommand request, CancellationToken cancellationToken)
    {
        await _loanRepository.Delete(request.Id);
        
        return Unit.Value;
    }
}
