using BibleStudy.Core.Models;

namespace BibleStudy.Core.Interfaces.Repositories;

public interface IVerseRepository
{
    Task<Verse> GetVerseWithoutVerseIdAsync(string translationAbbrev, string book, int chapter, int verseNumber, 
        CancellationToken cancellationToken = default);
}