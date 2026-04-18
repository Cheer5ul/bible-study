using BibleStudy.Core.DTOs;
using BibleStudy.Core.Exceptions.Repository;
using BibleStudy.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BibleStudy.Persistence.Repositories;

public class ChapterRepository : IChapterRepository
{
    private readonly BibleStudyDbContext _context;

    public ChapterRepository(BibleStudyDbContext context)
    {
        _context = context;
    }

    public async Task<ChapterDto> GetChapterAsync(string translationAbbrev, string book, int chapter,
        CancellationToken cancellationToken = default)
    {
        var bookId = await GetBookIdAsync(translationAbbrev, book, cancellationToken);

        if (bookId is null)
        {
            throw new BookNotFoundException(
                $"Book '{book}' with translation abbreviation {translationAbbrev} was not found");
        }

        var result = await _context.Verses
            .AsNoTracking()
            .Where(v => v.BookId == bookId &&
                        v.Chapter == chapter)
            .Select(v => new { v.VerseNumber, v.Text })
            .ToListAsync(cancellationToken);

        if (result is null || result.Count == 0)
        {
            throw new ChapterNotFoundException(
                $"Chapter not found {book} {chapter}");
        }

        // NOTE : MAKE SORTING BY VERSE NUMBER : BUG WITH JOHN 1 CHAPTER
        var verses = result.Select(v => new VerseLineDto(v.VerseNumber, v.Text)).ToList();

        var chapterDto = new ChapterDto(translationAbbrev, book, chapter, verses);

        return chapterDto;
    }

    public async Task<int> GetChaptersCountAsync(string translationAbbrev, string book,
        CancellationToken cancellationToken = default)
    {
        var bookId = await GetBookIdAsync(translationAbbrev, book, cancellationToken);

        if (bookId is null)
        {
            throw new BookNotFoundException(
                $"Book '{book}' with translation abbreviation {translationAbbrev} was not found");
        }

        var result = await _context.Verses
            .AsNoTracking()
            .Where(c => c.BookId == bookId)
            .MaxAsync(c => (int?)c.Chapter, cancellationToken); // returns null if not found

        if (result is null or 0 or < 0)
        {
            throw new CouldNotCountChaptersExceptions(
                $"Could not cound chapters in book {book} with translation abbreviation {translationAbbrev}");
        }
        
        return result.Value;
    }

    
    
    private async Task<int?> GetBookIdAsync(string translationAbbrev, string book,
        CancellationToken cancellationToken = default)
    {
        var bookId = await _context.Books
            .AsNoTracking()
            .Where(b => b.Name == book && b.TranslationAbbrev == translationAbbrev)
            .Select(b => (int?)b.Id) // returns null if not found
            .FirstOrDefaultAsync(cancellationToken);
        
        return bookId;
    }

}   