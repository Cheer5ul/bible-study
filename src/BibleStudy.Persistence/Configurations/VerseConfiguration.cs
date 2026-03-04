using BibleStudy.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibleStudy.Persistence.Configurations;

public class VerseConfiguration : IEntityTypeConfiguration<Verse>
{
    public void Configure(EntityTypeBuilder<Verse> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Text)
            .IsRequired();

        builder.HasOne<Book>()
            .WithMany()
            .HasForeignKey(x => x.BookId);
        
    }
}