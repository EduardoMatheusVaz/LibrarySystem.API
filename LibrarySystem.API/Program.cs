using FluentValidation.AspNetCore;
using LibrarySystem.API.Filters;
using LibrarySystem.Application.Commands;
using LibrarySystem.Application.Commands.CreateBook;
using LibrarySystem.Application.Validators.Book;
using LibrarySystem.Core.Repositories;
using LibrarySystem.Infrastructure.Persistence;
using LibrarySystem.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CreateBookCommandValidator>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Library System API", Version = "v1" });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

var connectionString = builder.Configuration.GetConnectionString("DataBase");
builder.Services.AddDbContext<LibrarySystemDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssemblyContaining(typeof(CreateBookCommandHandler)));

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
