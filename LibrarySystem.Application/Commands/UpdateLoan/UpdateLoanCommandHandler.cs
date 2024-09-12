using Azure.Core;
using Dapper;
using LibrarySystem.Core.Entities;
using LibrarySystem.Core.Repositories;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;
using MediatR.Wrappers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.UpdateLoan;

public class UpdateLoanCommandHandler : IRequestHandler<UpdateLoanCommand, Unit>
{
    private readonly ILoanRepository _loanRepository;

    public UpdateLoanCommandHandler(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<Unit> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = new Loan(request.UserId, request.BookId);

        await _loanRepository.Update(request.Id, loan);

        return Unit.Value;
    }
}
