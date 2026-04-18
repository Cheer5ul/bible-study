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
    private readonly ITranslationRepository _translationRepository;

    public ChapterService(IChapterRepository chapterRepository, ITranslationRepository translationRepository)
    {
        _chapterRepository = chapterRepository;
        _translationRepository = translationRepository;
    }
    
    public async Task<Result<ChapterDto>> GetChapterDtoAsync(string translationAbbrev, string book, int chapter,
        CancellationToken cancellationToken = default)
    {
        // checking if translation exists
        var isTranslationExists = await _translationRepository.TranslationExistsAsync(translationAbbrev, cancellationToken);

        if (isTranslationExists == false)
        {
            return Result<ChapterDto>.Failures([TranslationAbbrevErrors.NotFound(translationAbbrev)]);   
        }
        
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
    
    public async Task<Result<int>> GetChaptersCountAsync(string translationAbbrev, string book,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var resultChaptersCount =
                await _chapterRepository.GetChaptersCountAsync(translationAbbrev, book, cancellationToken);
            return Result<int>.Success(resultChaptersCount);
        }
        catch (BookNotFoundException ex)
        {
            return Result<int>.Failures([BookErrors.NotFound(book)]);
        }
        catch (CouldNotCountChaptersExceptions ex)
        {
            return Result<int>.Failures([ChapterErrors.CouldNotCountChapters(translationAbbrev, book)]);
        }
    }
}