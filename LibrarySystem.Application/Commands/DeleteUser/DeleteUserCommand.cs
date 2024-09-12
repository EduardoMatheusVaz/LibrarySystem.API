﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<Unit>
{
    public DeleteUserCommand(int id)
    {
        Id = id;
    }

    public int Id{ get; set; }
}
