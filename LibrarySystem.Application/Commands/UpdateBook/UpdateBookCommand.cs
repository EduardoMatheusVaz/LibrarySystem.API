using MediatR;
using LibrarySystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.UpdateBook;

public class UpdateBookCommand : IRequest<Unit>
{
    public UpdateBookCommand(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? ISBN { get; set; }
    public int? Year { get; set; }
    public string? Synopsis { get; set; }
}
