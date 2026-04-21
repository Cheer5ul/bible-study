using BibleStudy.Core.Results;

namespace BibleStudy.Core.Interfaces.Services;

public interface ITranslationService
{
    Task<Result<List<string>>> GetAllBookNamesAsync(
        string translationAbbrev,
        CancellationToken cancellationToken = default);
}