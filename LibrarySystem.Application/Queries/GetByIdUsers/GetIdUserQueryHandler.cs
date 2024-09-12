using Dapper;
using LibrarySystem.Application.ViewModels;
using LibrarySystem.Core.Repositories;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Queries.GetByIdUsers;

public class GetIdUserQueryHandler : IRequestHandler<GetIdUserQuery, UserParticularityViewModel>
{
    private readonly IUserRepository _userRepository;

    public GetIdUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserParticularityViewModel> Handle(GetIdUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        var userParticularity = new UserParticularityViewModel(user.Id, user.Name, user.Email, user.Phone);

        return userParticularity;
    }
}
