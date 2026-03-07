using BibleStudy.Core.Interfaces;
using BibleStudy.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BibleStudy.Persistence.Repositories;


public class VersesRepository : IVersesRepository
{
    private readonly BibleStudyDbContext _context;

    public VersesRepository(BibleStudyDbContext context)
    {
        _context = context;
    }

    public async Task<string> GetVerseTextAsync(string translationAbbrev, string book, int chapter, int verseNumber)
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