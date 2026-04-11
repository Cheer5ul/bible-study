using BibleStudy.API.Contracts.Verse;
using BibleStudy.Core.Results.Errors;
using FluentValidation;

namespace BibleStudy.API.Validators;

public class ChapterRequestValidator : AbstractValidator<ChapterRequest>
{
    // Bible book names for request validation
    // Canonical list is maintained here since validation is API-layer concern
    private static readonly string[] ValidBooks =
    {
        "Genesis", "Exodus", "Leviticus", "Numbers", "Deuteronomy", "Joshua", "Judges", "Ruth",
        "1 Samuel", "2 Samuel", "1 Kings", "2 Kings", "1 Chronicles", "2 Chronicles", "Ezra",
        "Nehemiah", "Esther", "Job", "Psalms", "Proverbs", "Ecclesiastes", "Song of Solomon",
        "Isaiah", "Jeremiah", "Lamentations", "Ezekiel", "Daniel", "Hosea", "Joel", "Amos",
        "Obadiah", "Jonah", "Micah", "Nahum", "Habakkuk", "Zephaniah", "Haggai", "Zechariah",
        "Malachi", "Matthew", "Mark", "Luke", "John", "Acts", "Romans", "1 Corinthians",
        "2 Corinthians", "Galatians", "Ephesians", "Philippians", "Colossians",
        "1 Thessalonians", "2 Thessalonians", "1 Timothy", "2 Timothy", "Titus", "Philemon",
        "Hebrews", "James", "1 Peter", "2 Peter", "1 John", "2 John", "3 John", "Jude",
        "Revelation"
    };

    private static readonly string[] ValidTranslationAbbreviations =
    {
        "ASV", "KJV"
    };
    
    public ChapterRequestValidator()
    {
        RuleFor(x => x.TranslationAbbrev)
            .NotEmpty()
            .Must(t => ValidTranslationAbbreviations.Contains(t))
            .WithErrorCode(TranslationAbbrevErrors.NotFoundCode)
            .WithMessage("Translation abbreviation '{PropertyValue}' is not a valid translation abbreviation name.");

        RuleFor(x => x.Book)
            .NotEmpty()
            .Must(b => ValidBooks.Contains(b))
            .WithErrorCode(BookErrors.NotFoundCode)
            .WithMessage("Book '{PropertyValue}' is not a valid Bible book name.");

        RuleFor(x => x.Chapter)
            .GreaterThan(0);
    }
}