using BibleStudy.Core.DTOs;
using BibleStudy.Core.Results;

namespace BibleStudy.Core.Interfaces.Services;

public interface IVerseService
{
    /// <summary>
    /// Retrieves a Result object by translation, book name, chapter and verse number
    /// </summary>
    /// <param name="translationAbbrev">Translation abbreviation e.g. "KJV", "NIV"</param>
    /// <param name="book">Full book name e.g. "Genesis"</param>
    /// <param name="chapter">Chapter number</param>
    /// <param name="verseNumber">Verse number</param>
    /// <param name="cancellationToken">Cancellation token to cancel asynchronous operation (optional)</param>
    /// <returns>
    /// Success: VerseDto with book name, chapter, verse number and text
    /// Failure: NotFound error when book or verse does not exist 
    /// </returns>
    Task<Result<VerseDto>> GetVerseDtoAsync(string translationAbbrev, string book, int chapter, int verseNumber,
        CancellationToken cancellationToken = default);

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
}