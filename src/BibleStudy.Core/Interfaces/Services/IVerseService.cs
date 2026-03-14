using BibleStudy.Core.Models;

namespace BibleStudy.Core.Interfaces.Services;

public interface IVerseService
{
    Task<Verse> GetVerseWithoutVerseIdAsync(string translationAbbrev, string book, int chapter, int verseNumber,
        CancellationToken cancellationToken = default);
}