using BibleStudy.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibleStudy.Persistence.Configurations;

public class TranslationConfiguration : IEntityTypeConfiguration<Translation> 
{
    public void Configure(EntityTypeBuilder<Translation> builder)
    {
        builder.HasKey(x => x.TranslationAbbrev);
        
        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(255);
        
        builder.Property(x => x.License)
            .HasMaxLength(500);
    }
}