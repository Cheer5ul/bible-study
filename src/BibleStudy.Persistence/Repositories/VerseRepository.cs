using BibleStudy.Core.DTOs;
using BibleStudy.Core.Exceptions.Repository;
using BibleStudy.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BibleStudy.Persistence.Repositories;


public class VerseRepository : IVerseRepository
{
    private readonly BibleStudyDbContext _context;

    public VerseRepository(BibleStudyDbContext context)
    {
        _context = context;
    }

    public async Task<VerseDto> GetVerseDtoAsync(string translationAbbrev, string book, int chapter, int verseNumber,
        CancellationToken cancellationToken = default)
    {

        var bookId = await _context.Books
            .AsNoTracking()
            .Where(b => b.Name == book)
            .Select(b => (int?)b.Id)  // returns null if not found 
            .FirstOrDefaultAsync(cancellationToken);

        if (bookId is null)
        {
            throw new BookNotFoundException($"Book '{book}' not found");
        }

        var result = await _context.Verses
            .AsNoTracking()
            .Where(v => v.BookId == bookId &&
                        v.Chapter == chapter &&
                        v.VerseNumber == verseNumber)
            .Select(v => v.Text)
            .FirstOrDefaultAsync(cancellationToken);

        if (result == null)
        {
            throw new VerseNotFoundException(
                $"Verse not found {book} {chapter}:{verseNumber}");
        }
        
        var verse = new VerseDto(book, chapter, verseNumber, result);

        return verse;
    }

    public async Task<ChapterDto> GetChapterAsync(string translationAbbrev, string book, int chapter,
        CancellationToken cancellationToken = default)
    {
        var bookId = await _context.Books
            .AsNoTracking()
            .Where(b => b.Name == book)
            .Select(b => (int?)b.Id) // returns null if not found
            .FirstOrDefaultAsync(cancellationToken);

        if (bookId is null)
        {
            throw new BookNotFoundException($"Book '{book}' not found");
        }

        var result = await _context.Verses
            .AsNoTracking()
            .Where(v => v.BookId == bookId &&
                        v.Chapter == chapter)
            .Select(v => new {v.VerseNumber, v.Text})
            .ToListAsync(cancellationToken);

        var verses = result.Select(v => new VerseLineDto(v.VerseNumber, v.Text)).ToList();
        
        var chapterDto = new ChapterDto(translationAbbrev, book, chapter, verses);
        
        return chapterDto;
    }
}