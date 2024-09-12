using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.LoanReserved;

public class LoanReservedCommand : IRequest<Unit>
{
    public LoanReservedCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
