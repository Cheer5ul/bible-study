using BibleStudy.Core.Interfaces;
using BibleStudy.Core.Interfaces.Repositories;
using BibleStudy.Core.Interfaces.Services;

namespace BibleStudy.Application.Services;

public class VerseService : IVerseService
{
    private readonly IVerseRepository _verseRepository;

    public VerseService(IVerseRepository verseRepository)
    {
        _verseRepository = verseRepository;
    }

    public async Task<string> GetVerseTextAsync(string translationAbbrev, string book, int chapter, int verseNumber, 
        CancellationToken cancellationToken = default)
    {
        return await _verseRepository.GetVerseTextAsync(translationAbbrev, book, chapter, verseNumber);
    }
}