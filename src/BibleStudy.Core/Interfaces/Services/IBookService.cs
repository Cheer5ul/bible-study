using BibleStudy.Core.Results;

namespace BibleStudy.Application.Services;

public interface IBookService
{
    Task<Result<List<string>>> GetAllBookNamesAsync(
        string translationAbbrev,
        CancellationToken cancellationToken = default);
}