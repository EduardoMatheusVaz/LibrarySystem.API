using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.BooksDelete;

public class BooksDeleteCommand : IRequest<Unit>
{
    public BooksDeleteCommand(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
