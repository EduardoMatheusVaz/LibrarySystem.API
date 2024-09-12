using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.UserActive;

public class UserActiveCommand : IRequest<Unit>
{
    public UserActiveCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
