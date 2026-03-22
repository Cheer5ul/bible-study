using BibleStudy.Core.DTOs;
using BibleStudy.Core.Exceptions.Repository;
using BibleStudy.Core.Interfaces.Repositories;
using BibleStudy.Core.Interfaces.Services;
using BibleStudy.Core.Results;
using BibleStudy.Core.Results.Errors;

namespace BibleStudy.Application.Services;

public class ChapterService : IChapterService
{
    private readonly IChapterRepository _chapterRepository;

    public ChapterService(IChapterRepository chapterRepository)
    {
        _chapterRepository = chapterRepository;
    }
    
    public async Task<Result<ChapterDto>> GetChapterDtoAsync(string translationAbbrev, string book, int chapter,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var resultChapter = await _chapterRepository
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