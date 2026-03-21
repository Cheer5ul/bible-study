using BibleStudy.API.Contracts.Verse;
using BibleStudy.Core.DTOs;
using BibleStudy.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudy.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VerseController : ControllerBase
{
    private readonly IVerseService _verseService;

    public VerseController(IVerseService verseService)
    {
        _verseService = verseService;
    }

    [HttpGet("get-verse")]
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
            return BadRequest(result.Errors);
        }
        
        return Ok(result.Value);
    }

    [HttpGet("get-chapter")]
    public async Task<ActionResult<ChapterDto>> GetChapterAsync([FromQuery] ChapterRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _verseService.GetChapterDtoAsync(
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