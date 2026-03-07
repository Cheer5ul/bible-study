namespace BibleStudy.Core.Interfaces;

public interface IVersesRepository
{
    Task<string> GetVerseTextAsync(string translationAbbrev, string book, int chapter, int verseNumber);
}