using LibrarySystem.Application.Commands.CreateLoan;
using LibrarySystem.Application.Commands.DeleteLoan;
using LibrarySystem.Application.Commands.LoanActive;
using LibrarySystem.Application.Commands.LoanCancelled;
using LibrarySystem.Application.Commands.LoanLate;
using LibrarySystem.Application.Commands.LoanReserved;
using LibrarySystem.Application.Commands.LoanReturned;
using LibrarySystem.Application.Commands.UpdateLoan;
using LibrarySystem.Application.Queries.GetAllLoan;
using LibrarySystem.Application.Queries.GetByIdLoan;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace LibrarySystem.API.Controllers;

[Route("api/loans")]
public class LoansController : ControllerBase
{
    private readonly IMediator _mediator;

    public LoansController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLoanCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = id }, command);
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllQuery();

        var loans = await _mediator.Send(query);

        return Ok(loans);
    }


    // api/loans/1, 2, 3, 4...
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetByIdQuery(id);

        var loan = await _mediator.Send(query);

        return Ok(loan);
    }



    // api/loans/1, 2, 3, 4...
    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateLoanCommand command)
    {
        var loan = new UpdateLoanCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }


    [HttpPut("active/{id}")]
    public async Task<IActionResult> Active(int id)
    {
        var command = new LoanActiveCommand(id);

        var loan = _mediator.Send(command);

        return NoContent();
    }

    [HttpPut("returned/{id}")]
    public async Task<IActionResult> Returned(int id)
    {
        var command = new LoanReturnedCommand(id);

        await _mediator.Send(command);

        return NoContent();
        

    }


    [HttpPut("late/{id}")]
    public async Task<IActionResult> Late(int id)
    {
        var command = new LoanLateCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }


    [HttpPut("reserved/{id}")]
    public async Task<IActionResult> Reserved(int id)
    {
        var command = new LoanReservedCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }


    [HttpPut("cancelled/{id}")]
    public async Task<IActionResult> Cancelled(int id)
    {
        var command = new LoanCancelledCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }


    // api/loans/1, 2, 3, 4...
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new LoanDeleteCommand(id);

        var delete = await _mediator.Send(command);

        return NoContent();
    }

}