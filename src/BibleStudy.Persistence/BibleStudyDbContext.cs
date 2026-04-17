using System.Reflection;
using BibleStudy.Core.Models;
using BibleStudy.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BibleStudy.Persistence;

public class BibleStudyDbContext : DbContext
{
    public BibleStudyDbContext(DbContextOptions<BibleStudyDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<Book> Books { get; set; }
    public DbSet<Verse> Verses { get; set; }
    public DbSet<Translation> Translations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}