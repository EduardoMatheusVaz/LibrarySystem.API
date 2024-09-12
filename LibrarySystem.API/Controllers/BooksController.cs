    using LibrarySystem.Application.Commands.BookRented;
using LibrarySystem.Application.Commands.BooksAvailable;
using LibrarySystem.Application.Commands.BooksDelete;
using LibrarySystem.Application.Commands.BooksLate;
using LibrarySystem.Application.Commands.CreateBook;
using LibrarySystem.Application.Commands.UpdateBook;
using LibrarySystem.Application.Queries.GetAllBooks;
using LibrarySystem.Application.Queries.GetByIdBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace LibrarySystem.API.Controllers;

[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BooksController( IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = id }, command);
    }


    // api/books?query=net.dasetc
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllQuery();

        var books = await _mediator.Send(query);

        return Ok(books);
    }


    // api/books/1, 2, 3, 4
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetIdBookQuery(id);

        var book = await _mediator.Send(query);

        if (query == null)
        {
            return NotFound();
        }
        
        return Ok(book);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateBookCommand command)
    {
        var update = new UpdateBookCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }


    [HttpPut("{id}/Avaible")]
    public async Task<IActionResult> Avaible(int id)
    {
        var command = new BooksAvailableCommand(id);

        await _mediator.Send(command);

        return NoContent();

    }


    [HttpPut("{id}/Rented")]
    public async Task<IActionResult> Rented(int id)
    {
        var command = new BookRentedCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }


    [HttpPut("{id}/Late")]
    public IActionResult Late(int id)
    {
        var command = new BooksLateCommand(id);

        _mediator.Send(command);

        return NoContent();
    }


    [HttpPut("{id}/Reserved")]
    public async Task<IActionResult> Reserved(int id)
    {
        var book = new BookRentedCommand(id);

        await _mediator.Send(book);

        return NoContent();
    }

    // api/books/1, 2, 3, 4
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new BooksDeleteCommand(id);
        
        await _mediator.Send(command);
        
        return NoContent();
    }    
}
