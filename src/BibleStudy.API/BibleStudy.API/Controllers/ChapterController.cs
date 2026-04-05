using BibleStudy.API.Contracts.Verse;
using BibleStudy.API.Handlers;
using BibleStudy.Core.DTOs;
using BibleStudy.Core.Interfaces.Services;
using BibleStudy.Core.Results;
using BibleStudy.Core.Results.Errors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace BibleStudy.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChapterController : ControllerBase
{
    private readonly IChapterService _chapterService;
    private readonly IFailureHandler _failureHandler;
    private readonly IValidator<ChapterRequest> _validator;
    
    public ChapterController(
        IChapterService chapterService, 
        IFailureHandler failureHandler,
        IValidator<ChapterRequest> validator)
    {
        _chapterService = chapterService;
        _failureHandler = failureHandler;
        _validator = validator;
    }
    
    [HttpGet]
    public async Task<ActionResult<ChapterDto>> GetChapterAsync([FromQuery] ChapterRequest request,
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .Select(e => new Error(e.ErrorCode, e.ErrorMessage))
                .ToList();
            
            var validationErrorResult = Result<ChapterRequest>.Failures(errors);

            return await _failureHandler.HandleFailure(validationErrorResult, HttpContext);
        }
        
        var result = await _chapterService.GetChapterDtoAsync(
            request.TranslationAbbrev,
            request.Book,
            request.Chapter,
            cancellationToken);

        if (result.IsFailure)
        {
            return await _failureHandler.HandleFailure(result, HttpContext);
        }
        
        return Ok(result.Value);
    }
}