using LibrarySystem.Application.ViewModels;
using MediatR;


namespace LibrarySystem.Application.Queries.GetByIdBooks;
public class GetIdBookQuery : IRequest<BookParticularityViewModel>
{
    public GetIdBookQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
