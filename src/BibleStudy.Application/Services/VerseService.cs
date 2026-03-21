using BibleStudy.Core.DTOs;
using BibleStudy.Core.Exceptions.Repository;
using BibleStudy.Core.Interfaces.Repositories;
using BibleStudy.Core.Interfaces.Services;
using BibleStudy.Core.Results;
using BibleStudy.Core.Results.Errors;

namespace BibleStudy.Application.Services;

public class VerseService : IVerseService
{
    private readonly IVerseRepository _verseRepository;

    public VerseService(IVerseRepository verseRepository)
    {
        _verseRepository = verseRepository;
    }

    public async Task<Result<VerseDto>> GetVerseDtoAsync(string translationAbbrev, string book, int chapter, int verseNumber, 
        CancellationToken cancellationToken = default)
    {
        try
        {
            var resultVerse = await _verseRepository
                .GetVerseDtoAsync(translationAbbrev, book, chapter, verseNumber, cancellationToken);
            return Result<VerseDto>.Success(resultVerse);
        }
        catch (BookNotFoundException ex)
        {
            return Result<VerseDto>.Failures([BookErrors.NotFound(book)]);
        }
        catch (VerseNotFoundException ex)
        {
            return Result<VerseDto>.Failures([VerseErrors.NotFound(book,  chapter, verseNumber)]);
        }
    }

    public async Task<Result<ChapterDto>> GetChapterDtoAsync(string translationAbbrev, string book, int chapter,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var resultChapter = await _verseRepository
                .GetChapterAsync(translationAbbrev, book, chapter, cancellationToken);
            return Result<ChapterDto>.Success(resultChapter);
        }
        catch (BookNotFoundException ex)
        {
            return Result<ChapterDto>.Failures([BookErrors.NotFound(book)]);
        }
        catch (ChapterNotFoundException ex)
        {
            return Result<ChapterDto>.Failures([ChapterErrors.NotFound(book, chapter)]);
        }
    }
}