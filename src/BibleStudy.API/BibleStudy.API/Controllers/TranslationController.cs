using BibleStudy.API.Handlers;
using BibleStudy.Application.Services;
using BibleStudy.Core.Interfaces.Services;
using BibleStudy.Core.Models;
using BibleStudy.Core.Results;
using BibleStudy.Core.Results.Errors;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudy.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TranslationController : ControllerBase
{
    private readonly ITranslationService _translationService;
    private readonly IFailureHandler _failureHandler;
    private readonly IValidator<string> _validator;

    public TranslationController(
        ITranslationService translationService,
        IFailureHandler failureHandler,
        IValidator<string> validator)
    {
        _translationService = translationService;
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

        var result = await _translationService.GetAllBookNamesAsync(translationAbbrev, cancellationToken);

        if (result.IsFailure)
        {
            return await _failureHandler.HandleFailure(result, HttpContext);
        }
        
        return Ok(result.Value);
    }
}