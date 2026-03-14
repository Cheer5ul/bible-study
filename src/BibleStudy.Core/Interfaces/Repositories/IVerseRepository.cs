using BibleStudy.Core.DTOs;

namespace BibleStudy.Core.Interfaces.Repositories;

public interface IVerseRepository
{
    Task<VerseDto> GetVerseWithoutVerseIdAsync(string translationAbbrev, string book, int chapter, int verseNumber, 
        CancellationToken cancellationToken = default);
}