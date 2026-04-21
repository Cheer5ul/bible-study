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
    
}