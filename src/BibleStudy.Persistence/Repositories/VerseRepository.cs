using BibleStudy.Core.Interfaces;
using BibleStudy.Core.Interfaces.Repositories;
using BibleStudy.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BibleStudy.Persistence.Repositories;


public class VerseRepository : IVerseRepository
{
    private readonly BibleStudyDbContext _context;

    public VerseRepository(BibleStudyDbContext context)
    {
        _context = context;
    }

    public async Task<Verse> GetVerseWithoutVerseIdAsync(string translationAbbrev, string book, int chapter, int verseNumber,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var bookId = await _context.Books
                .AsNoTracking()
                .Where(b => b.Name == book)
                .Select(b => b.Id)
                .FirstOrDefaultAsync(cancellationToken);

            var result = await _context.Verses
                .AsNoTracking()
                .Where(v => v.BookId == bookId &&
                            v.Chapter == chapter &&
                            v.VerseNumber == verseNumber)
                .Select(v => v.Text)
                .FirstOrDefaultAsync(cancellationToken);

            var verse = Verse.AssembleVerseWithoutVerseId(bookId, chapter, verseNumber, result);

            return verse;
        }
        catch (Exception ex)
        {
            throw new Exception("Exception thrown while getting verse", ex);
        }
    }
}