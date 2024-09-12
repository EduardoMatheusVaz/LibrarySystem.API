using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.DeleteLoan;

public class LoanDeleteCommand : IRequest<Unit>
{
    public LoanDeleteCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
