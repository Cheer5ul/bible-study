using BibleStudy.Core.Exceptions.Repository;

namespace BibleStudy.Core.Interfaces.Repositories;

public interface ITranslationRepository
{
    /// <summary>
    /// Checks whether the specific translations exists in the database
    /// </summary>
    /// <param name="translationAbbrev">Translation abbreviation e.g. "KJV", "NIV"</param>
    /// <param name="cancellationToken">Cancellation token to cancel asynchronous operation (optional)</param>
    /// <returns>True if translation exists; otherwise false</returns>
    Task<bool> TranslationExistsAsync(string translationAbbrev,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves all books of the Bible by translation
    /// </summary>
    /// <param name="translationAbbrev">Translation abbreviation e.g. "KJV", "NIV"</param>
    /// <param name="cancellationToken">Cancellation token to cancel asynchronous operation (optional)</param>
    /// <returns>List of book names for the specified translation</returns>
    /// <exception cref="BookListIsEmpty">Thrown when no books are found for the given translation</exception>
    Task<List<string>> GetAllBookNamesAsync(string translationAbbrev,
        CancellationToken cancellationToken = default);
}