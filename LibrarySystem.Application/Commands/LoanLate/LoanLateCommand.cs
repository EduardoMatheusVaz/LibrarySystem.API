using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.LoanLate;

public class LoanLateCommand : IRequest<Unit>
{
    public LoanLateCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
