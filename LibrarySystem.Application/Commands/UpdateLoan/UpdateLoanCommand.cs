using LibrarySystem.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.UpdateLoan;

public class UpdateLoanCommand : IRequest<Unit>
{
    public UpdateLoanCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
    public DateTime? Date { get; set; }
    public LoanStatusEnum? Status { get; set; }
}
