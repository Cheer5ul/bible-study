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

    [HttpGet]
    public async Task<ActionResult<string>> GetVerseTextAsync(string translationAbbrev, string book, int chapter, int verseNumber, 
        CancellationToken cancellationToken)
    {
        var verseText =
            await _verseService.GetVerseTextAsync(translationAbbrev, book, chapter, verseNumber, cancellationToken);
        return Ok(verseText);
    }
}