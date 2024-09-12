using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.LoanReturned;

public class LoanReturnedCommand : IRequest<Unit>
{
    public LoanReturnedCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
