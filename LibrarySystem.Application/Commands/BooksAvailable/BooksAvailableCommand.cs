using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.BooksAvailable;

public class BooksAvailableCommand : IRequest<Unit>
{
    public BooksAvailableCommand(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }

}
