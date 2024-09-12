using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.LoanActive;

public class LoanActiveCommand : IRequest<Unit>
{
    public LoanActiveCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
