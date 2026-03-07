namespace BibleStudy.Core.Interfaces;

public interface IVerseRepository
{
    Task<string> GetVerseTextAsync(string translationAbbrev, string book, int chapter, int verseNumber);
}