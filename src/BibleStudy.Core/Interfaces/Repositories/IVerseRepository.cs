using BibleStudy.Core.DTOs;
using BibleStudy.Core.Exceptions.Repository;

namespace BibleStudy.Core.Interfaces.Repositories;

public interface IVerseRepository
{
    /// <summary>
    /// Retrieves a verse by translation, book name, chapter and verse number
    /// </summary>
    /// <param name="translationAbbrev">Translation abbreviation e.g. "KJV", "NIV"</param>
    /// <param name="book">Full book name e.g. "Genesis"</param>
    /// <param name="chapter">Chapter number</param>
    /// <param name="verseNumber">Verse number</param>
    /// <param name="cancellationToken">Cancellation token to cancel asynchronous operation (optional)</param>
    /// <returns>VerseDto with book name, chapter, verse number and text</returns>
    /// <exception cref="BookNotFoundException">Thrown when book is not found</exception>
    /// <exception cref="VerseNotFoundException">Thrown when verse is not found</exception>
    Task<VerseDto> GetVerseDtoAsync(string translationAbbrev, string book, int chapter, int verseNumber, 
        CancellationToken cancellationToken = default);
        
    /// <summary>
    /// Retrieves a chapter by translation, book name and chapter number
    /// </summary>
    /// <param name="translationAbbrev">Translation abbreviation e.g. "KJV", "NIV"</param>
    /// <param name="book">Full book name e.g. "Genesis"</param>
    /// <param name="chapter">Chapter number</param>
    /// <param name="cancellationToken">Cancellation token to cancel asynchronous operation (optional)</param>
    /// <returns>ChapterDto with translation abbreviation, book name, chapter number and IReadOnlyList of VerseLineDto</returns>
    /// <exception cref="BookNotFoundException">Thrown when book is not found</exception>
    /// <exception cref="ChapterNotFoundException">Thrown when chapter is not found</exception>

    Task<ChapterDto> GetChapterAsync(string translationAbbrev, string book, int chapter,
        CancellationToken cancellationToken = default);
}