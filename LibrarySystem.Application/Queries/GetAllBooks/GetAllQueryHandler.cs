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

namespace LibrarySystem.Application.Queries.GetAllBooks;
public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<BookViewModel>>
{
    private readonly IBookRepository _bookRepository;

    public GetAllQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<List<BookViewModel>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetAllAsync();

        var booksViewModel = books.Select(b => new BookViewModel(
            b.Id,
            b.Title,
            b.Author,
            b.ISBN,
            b.Year,
            b.Synopsis
            ));

        return booksViewModel.ToList();


        /*
        MÉTODO FEITO EM ENTITY FRAMEWORK SEM QUERY E DAPPER
            var books = _dbcontext.Book;
            var booksViewModels = books
            .Select(p => new BookViewModel
                (p.Title,
                p.Author,
                p.ISBN,
                p.Year, 
                p.Synopsis))
        .ToList();    
        return booksViewModels;   

        OU

        var books = _dbcontext.Book;
        var booksList = books
            .Select(s => new BookViewModel(s.Id, s.Title))
            .ToList();
        return booksList;
        */
    }
}
