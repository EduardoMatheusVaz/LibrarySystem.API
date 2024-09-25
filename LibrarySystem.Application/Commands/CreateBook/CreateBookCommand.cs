using LibrarySystem.Core.Enums;
using MediatR;
using System.Text.Json.Serialization;

namespace LibrarySystem.Application.Commands.CreateBook;

public class CreateBookCommand : IRequest<int>
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int Year { get; set; }
    public string Synopsis { get; set; }
    public string Gender{ get; set; }
}
