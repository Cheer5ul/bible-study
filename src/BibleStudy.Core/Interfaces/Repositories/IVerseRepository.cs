namespace BibleStudy.Core.Interfaces.Repositories;

public interface IVerseRepository
{
    Task<string> GetVerseTextAsync(string translationAbbrev, string book, int chapter, int verseNumber, 
        CancellationToken cancellationToken = default);
}