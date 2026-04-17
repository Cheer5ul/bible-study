using BibleStudy.Core.DTOs;

namespace BibleStudy.Persistence.Repositories;

public class TranslationRepository
{
    private readonly BibleStudyDbContext _context;

    public TranslationRepository(BibleStudyDbContext context)
    {
        _context = context;
    }

    public async Task<TranslationDto> GetTranslation(
        string translationAbbrev,
        CancellationToken cancellationToken = default)
    {
        return null;
    }
}