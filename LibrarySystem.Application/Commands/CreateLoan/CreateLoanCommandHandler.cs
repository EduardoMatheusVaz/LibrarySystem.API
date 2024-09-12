using LibrarySystem.Core.Entities;
using LibrarySystem.Core.Repositories;
using LibrarySystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.CreateLoan;

public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, int>
{
    private readonly ILoanRepository _loanRepository;
    private readonly LibrarySystemDbContext _dbcontext;

    public CreateLoanCommandHandler(ILoanRepository loanRepository, LibrarySystemDbContext dbcontext)
    {
        _loanRepository = loanRepository;
        _dbcontext = dbcontext;
    }

    public async Task<int> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
    {
        var newLoan = new Loan(request.UserId, request.BookId);
        var loan = _loanRepository.Create(newLoan);
        await _dbcontext.SaveChangesAsync();

        return newLoan.Id;  
    }
}
