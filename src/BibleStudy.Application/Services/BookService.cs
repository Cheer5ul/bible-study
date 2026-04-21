using BibleStudy.Core.Interfaces.Repositories;
using BibleStudy.Core.Interfaces.Services;
using BibleStudy.Core.Results;
using BibleStudy.Core.Results.Errors;

namespace BibleStudy.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly ITranslationRepository _translationRepository;
    
    public BookService(
        IBookRepository bookRepository, 
        ITranslationRepository translationRepository)
    {
        _bookRepository = bookRepository;
        _translationRepository = translationRepository;
    }

}