using BibleStudy.API.Handlers;
using BibleStudy.API.Validators;
using BibleStudy.Application.Services;
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

    [HttpGet]
    public async Task<ActionResult<List<string>>> GetAllBookNames(
        [FromQuery] string translationAbbrev,
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(translationAbbrev, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .Select(e => new Error(e.ErrorCode, e.ErrorMessage))
                .ToList();
            
            var validationErrorForResult = Result<List<string>>.Failures(errors);

            return await _failureHandler.HandleFailure(validationErrorForResult, HttpContext);
        }

        var result = await _bookService.GetAllBookNamesAsync(translationAbbrev, cancellationToken);

        if (result.IsFailure)
        {
            return await _failureHandler.HandleFailure(result, HttpContext);
        }
        
        return Ok(result.Value);
    }
}