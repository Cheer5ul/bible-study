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

    public async Task<string> GetVerseTextAsync(string translationAbbrev, string book, int chapter, int verseNumber,
        CancellationToken cancellationToken = default)
    {
        var bookId = await _context.Books
            .AsNoTracking()
            .Where(b => b.Name == book)
            .Select(b => b.Id)
            .FirstOrDefaultAsync();

        var result = await _context.Verses
            .AsNoTracking()
            .Where(v => v.BookId == bookId &&
                        v.Chapter == chapter &&
                        v.VerseNumber == verseNumber)
            .Select(v => v.Text)
            .FirstOrDefaultAsync();

        return result;
    }
}