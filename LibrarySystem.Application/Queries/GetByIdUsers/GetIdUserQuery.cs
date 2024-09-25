using LibrarySystem.Application.ViewModels;
using MediatR;


namespace LibrarySystem.Application.Queries.GetByIdUsers;

public class GetIdUserQuery : IRequest<UserParticularityViewModel>
{
    public GetIdUserQuery(int id)
    {
        Id = id;

    }

    public int Id { get; set; }
}
