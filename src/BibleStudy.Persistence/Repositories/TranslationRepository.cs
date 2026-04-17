using BibleStudy.Core.DTOs;
using BibleStudy.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BibleStudy.Persistence.Repositories;

public class TranslationRepository : ITranslationRepository
{
    private readonly BibleStudyDbContext _context;

    public TranslationRepository(BibleStudyDbContext context)
    {
        _context = context;
    }

    public async Task<bool> TranslationExistsAsync(string translationAbbrev,
        CancellationToken cancellationToken = default)
    {
        var translation = await _context.Translations
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TranslationAbbrev == translationAbbrev, cancellationToken);

        if (translation == null) return false;
        
        return true;
    }
}