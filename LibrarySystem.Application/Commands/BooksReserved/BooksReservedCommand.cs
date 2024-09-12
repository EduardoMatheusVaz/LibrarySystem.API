using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.BooksReserved;

public class BooksReservedCommand : IRequest<Unit>
{
    public BooksReservedCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
