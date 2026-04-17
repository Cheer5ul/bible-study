using BibleStudy.Core.DTOs;
using BibleStudy.Core.Exceptions.Repository;
using BibleStudy.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BibleStudy.Persistence.Repositories;

public class BookRepository
{
    private readonly BibleStudyDbContext _context;

    public BookRepository(BibleStudyDbContext context)
    {
        _context = context;
    }

    public async Task<List<BookDto>> GetAllBooks(string translationAbbrev,
        CancellationToken cancellationToken = default)
    {
        var books = await _context.Books
            .AsNoTracking()
            .Where(b => b.TranslationAbbrev == translationAbbrev)
            .Select(b => new BookDto(b.Name, b.TranslationAbbrev))
            .ToListAsync(cancellationToken);

        if (books.Count == 0)
        {
            throw new BookListIsEmpty(
                $"Books with translation {translationAbbrev} were not found");
        }
        
        return books;
    }
}