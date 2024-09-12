using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.BooksLate;

public class BooksLateCommand : IRequest<Unit>
{
    public BooksLateCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
