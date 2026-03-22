using BibleStudy.API.Contracts.Verse;
using BibleStudy.Core.DTOs;
using BibleStudy.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudy.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ChapterController : ControllerBase
{
    private readonly IChapterService _chapterService;
    
    public ChapterController(IChapterService chapterService)
    {
        _chapterService = chapterService;
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
            return BadRequest(result.Errors);
        }
        
        return Ok(result.Value);
    }
}