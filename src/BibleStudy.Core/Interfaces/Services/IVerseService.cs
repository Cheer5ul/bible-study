namespace BibleStudy.Core.Interfaces.Services;

public interface IVerseService
{
    Task<string> GetVerseTextAsync(string translationAbbrev, string book, int chapter, int verseNumber,
        CancellationToken cancellationToken = default);
}