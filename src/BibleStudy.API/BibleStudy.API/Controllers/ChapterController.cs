using BibleStudy.API.Contracts.Verse;
using BibleStudy.API.Handlers;
using BibleStudy.Core.DTOs;
using BibleStudy.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudy.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChapterController : ControllerBase
{
    private readonly IChapterService _chapterService;
    private readonly IFailureHandler _failureHandler;
    
    public ChapterController(IChapterService chapterService, IFailureHandler failureHandler)
    {
        _chapterService = chapterService;
        _failureHandler = failureHandler;
    }
    
    [HttpGet]
    public async Task<ActionResult<ChapterDto>> GetChapterAsync([FromQuery] ChapterRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _chapterService.GetChapterDtoAsync(
            request.TranslationAbbrev,
            request.Book,
            request.Chapter,
            cancellationToken);

        if (result.IsFailure)
        {
            var error = _failureHandler.HandleFailure(result, HttpContext);
            
            return BadRequest(error);
        }
        
        return Ok(result.Value);
    }
}