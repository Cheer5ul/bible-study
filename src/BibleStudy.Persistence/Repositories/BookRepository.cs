using BibleStudy.Core.DTOs;
using BibleStudy.Core.Exceptions.Repository;
using BibleStudy.Core.Interfaces.Repositories;
using BibleStudy.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BibleStudy.Persistence.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BibleStudyDbContext _context;

    public BookRepository(BibleStudyDbContext context)
    {
        _context = context;
    }

    public async Task<List<string>> GetAllBookNamesAsync(string translationAbbrev,
        CancellationToken cancellationToken = default)
    {
        var books = await _context.Books
            .AsNoTracking()
            .Where(b => b.TranslationAbbrev == translationAbbrev)
            .Select(b => b.Name)
            .ToListAsync(cancellationToken);

        if (books.Count == 0)
        {
            throw new BookListIsEmpty(
                $"Books with translation {translationAbbrev} were not found");
        }
        
        return books;
    }
}