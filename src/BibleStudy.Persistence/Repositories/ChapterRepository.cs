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
}