namespace BibleStudy.Persistence.Repositories;

public class VersesRepository
{
    private readonly BibleStudyDbContext _context;

    public VersesRepository(BibleStudyDbContext context)
    {
        _context = context;
    }
    
    
}