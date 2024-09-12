using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.UserOff;

public class UserOffCommand : IRequest<Unit>
{
    public UserOffCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
