using BibleStudy.API.Contracts.Verse;
using BibleStudy.API.Handlers;
using BibleStudy.Core.DTOs;
using BibleStudy.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudy.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VerseController : ControllerBase
{
    private readonly IVerseService _verseService;
    private readonly IFailureHandler _failureHandler;

    public VerseController(IVerseService verseService, IFailureHandler failureHandler)
    {
        _verseService = verseService;
        _failureHandler = failureHandler;
    }

    [HttpGet]
    public async Task<ActionResult<VerseDto>> GetVerseAsync([FromQuery] VerseRequest request, 
        CancellationToken cancellationToken)
    {
        var result = await _verseService.GetVerseDtoAsync(
            request.TranslationAbbrev,
            request.Book, 
            request.Chapter, 
            request.VerseNumber,
            cancellationToken);
        
        if (result.IsFailure)
        {
            var error = _failureHandler.HandleFailure(result, HttpContext);
            
            return BadRequest(error);
        }
        
        return Ok(result.Value);
    }
    
}