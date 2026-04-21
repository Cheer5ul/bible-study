using BibleStudy.Core.Interfaces.Repositories;
using BibleStudy.Core.Interfaces.Services;
using BibleStudy.Core.Results;
using BibleStudy.Core.Results.Errors;

namespace BibleStudy.Application.Services;

public class TranslationService : ITranslationService
{
    private readonly ITranslationRepository _translationRepository;

    public TranslationService(
        ITranslationRepository translationRepository,
        IBookRepository bookRepository)
    {
        _translationRepository = translationRepository;
    }
    
    
    public async Task<Result<List<string>>> GetAllBookNamesAsync(
        string translationAbbrev,
        CancellationToken cancellationToken = default)
    {
        // checking if translation exists
        var isTranslationExists = await _translationRepository.TranslationExistsAsync(translationAbbrev, cancellationToken);

        if (isTranslationExists == false)
        {
            return Result<List<string>>.Failures([TranslationAbbrevErrors.NotFound(translationAbbrev)]);   
        }

        var bookNames = await _translationRepository.GetAllBookNamesAsync(translationAbbrev, cancellationToken);
        
        return Result<List<string>>.Success(bookNames);
    }
}