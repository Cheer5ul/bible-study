using BibleStudy.Core.DTOs;
using BibleStudy.Core.Interfaces.Repositories;
using BibleStudy.Core.Interfaces.Services;
using BibleStudy.Core.Models;
using BibleStudy.Core.Results;

namespace BibleStudy.Application.Services;

public class VerseService : IVerseService
{
    private readonly IVerseRepository _verseRepository;

    public VerseService(IVerseRepository verseRepository)
    {
        _verseRepository = verseRepository;
    }

    public async Task<Result<VerseDto>> GetVerseDtoAsync(string translationAbbrev, string book, int chapter, int verseNumber, 
        CancellationToken cancellationToken = default)
    {
        try
        {
            var verse = await _verseRepository
                .GetVerseDtoAsync(translationAbbrev, book, chapter, verseNumber, cancellationToken);
            return Result<VerseDto>.Success(verse);
        }
        catch()
    }
}