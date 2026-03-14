using BibleStudy.Core.Interfaces.Repositories;
using BibleStudy.Core.Interfaces.Services;
using BibleStudy.Core.Models;

namespace BibleStudy.Application.Services;

public class VerseService : IVerseService
{
    private readonly IVerseRepository _verseRepository;

    public VerseService(IVerseRepository verseRepository)
    {
        _verseRepository = verseRepository;
    }

    public async Task<Verse> GetVerseWithoutVerseIdAsync(string translationAbbrev, string book, int chapter, int verseNumber, 
        CancellationToken cancellationToken = default)
    {
        
    }
}