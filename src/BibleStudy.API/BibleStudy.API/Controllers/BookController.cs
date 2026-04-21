using BibleStudy.API.Handlers;
using BibleStudy.API.Validators;
using BibleStudy.Application.Services;
using BibleStudy.Core.Interfaces.Services;
using BibleStudy.Core.Results;
using BibleStudy.Core.Results.Errors;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudy.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IFailureHandler _failureHandler;
    private readonly IValidator<string> _validator;
    
    public BookController(
        IBookService bookService,
        IFailureHandler failureHandler, 
        IValidator<string> validator)
    {
        _bookService = bookService;
        _failureHandler = failureHandler;
        _validator = validator;
    }
    
}