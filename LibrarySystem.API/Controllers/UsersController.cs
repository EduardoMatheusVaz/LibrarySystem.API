using LibrarySystem.Application.Commands.CreateUser;
using LibrarySystem.Application.Commands.DeleteUser;
using LibrarySystem.Application.Commands.UpdateUser;
using LibrarySystem.Application.Commands.UserActive;
using LibrarySystem.Application.Commands.UserOff;
using LibrarySystem.Application.Queries.GetAllUsers;
using LibrarySystem.Application.Queries.GetByIdUsers;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace LibrarySystem.API.Controllers;

[Route("api/users")]
public class UsersController : ControllerBase
{

    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
    {
        if (command.Name.Length > 65)
        {
            return BadRequest();
        }
        else if (command.Email.Length > 50)
        {
            return BadRequest();
        }

        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = id }, command);
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllUsersQuery();

        var users = await _mediator.Send(query);

        return Ok(users);
    }


    // api/users/1, 2, 3, 4...
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetIdUserQuery(id);

        var user = await _mediator.Send(query);

        return Ok(user);
    }


    [HttpPut("{id}/Update")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUserCommand command)
    {
        var update = new UpdateUserCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }


    [HttpPut("{id}/Active")]
    public async Task<IActionResult> Active(int id)
    {
        var command = new UserActiveCommand(id);

        var user = await _mediator.Send(command);

        return NoContent();
    }


    [HttpPut("{id}/Off")]
    public async Task<IActionResult> Off (int id)
    {
        var command = new UserOffCommand(id);

        var user = await _mediator.Send(command);

        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteUserCommand(id);

        var userDead = await _mediator.Send(command);

        return NoContent();
    }
}