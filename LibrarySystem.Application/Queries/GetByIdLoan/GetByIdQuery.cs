using LibrarySystem.Application.ViewModels;
using MediatR;


namespace LibrarySystem.Application.Queries.GetByIdLoan;

public class GetByIdQuery : IRequest<LoanParticularityViewModel>
{
    public GetByIdQuery(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}
