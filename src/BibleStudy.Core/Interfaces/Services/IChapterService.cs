using BibleStudy.Core.DTOs;
using BibleStudy.Core.Results;

namespace BibleStudy.Core.Interfaces.Services;

public interface IChapterService
{
    /// <summary>
    /// Retrieves a Result object by translation, book name, chapter and verse number
    /// </summary>
    /// <param name="translationAbbrev">Translation abbreviation e.g. "KJV", "NIV"</param>
    /// <param name="book">Full book name e.g. "Genesis"</param>
    /// <param name="chapter">Chapter number</param>
    /// <param name="cancellationToken">Cancellation token to cancel asynchronous operation (optional)</param>
    /// <returns>
    /// Success: ChapterDto with book name, chapter and IReadOnlyList of VerseLineDto
    /// Failure: NotFound error when book or chapter does not exist 
    /// </returns>
    Task<Result<ChapterDto>> GetChapterDtoAsync(string translationAbbrev, string book, int chapter,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves an integer representing the amount of chapters in certain book by translation and book name
    /// </summary>
    /// <param name="translationAbbrev">Translation abbreviation e.g. "KJV", "NIV"</param>
    /// <param name="book">Full book name e.g. "Genesis"</param>
    /// <param name="cancellationToken">Cancellation token to cancel asynchronous operation (optional)</param>
    /// <returns>
    /// Success: int, representing the amount of chapters
    /// Failure: NotFound error when book or translation does not exist, or when cound not count chapters properly 
    /// </returns>
    Task<Result<int>> GetChaptersCountAsync(string translationAbbrev, string book,
        CancellationToken cancellationToken = default);
}