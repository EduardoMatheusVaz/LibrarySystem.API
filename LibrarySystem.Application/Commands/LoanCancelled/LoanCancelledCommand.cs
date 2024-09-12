using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.LoanCancelled;

public class LoanCancelledCommand : IRequest<Unit>
{
    public LoanCancelledCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
