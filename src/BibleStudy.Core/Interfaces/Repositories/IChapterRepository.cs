using BibleStudy.Core.DTOs;
using BibleStudy.Core.Exceptions.Repository;

namespace BibleStudy.Core.Interfaces.Repositories;

public interface IChapterRepository
{
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

    /// <summary>
    /// Retrieves number of chapters in certain book by translation and book's name
    /// </summary>
    /// <param name="translationAbbrev">Translation abbreviation e.g. "KJV", "NIV"</param>
    /// <param name="book">Full book name e.g. "Genesis"</param>
    /// <param name="cancellationToken">Cancellation token to cancel asynchronous operation (optional)</param>
    /// <returns>ChapterDto with translation abbreviation, book name, chapter number and IReadOnlyList of VerseLineDto</returns>
    /// <exception cref="BookNotFoundException">Thrown when book is not found</exception>
    /// <exception cref="CouldNotCountChaptersExceptions">Thrown when it was impossible to count chapters</exception>
    Task<int> GetChaptersCountAsync(string translationAbbrev, string book,
        CancellationToken cancellationToken = default);
}