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
        "Revelation",
        "Бытие", "Исход", "Левит", "Числа", "Второзаконие", "Иисус Навин", "Судьи", "Руфь",
        "1-я Царств", "2-я Царств", "3-я Царств", "4-я Царств", "1-я Паралипоменон", "2-я Паралипоменон",
        "Молитва Манассии", "Ездра", "Неемия", "1-я Ездры", "Товит", "Иудифь", "Есфирь", "Иов", "Псалтирь",
        "Притчи", "Екклесиаст", "Песня Песней", "Премудрость Соломона", "Сирах", "Исаия", "Иеремия",
        "Плач Иеремии", "Послание Иеремии", "Варух", "Иезекииль", "Даниил", "Осия", "Иоиль", "Амос", "Авдий",
        "Иона", "Михей", "Наум", "Аввакум", "Софония", "Аггей", "Захария", "Малахия", "1-я Маккавейская", 
        "2-я Маккавейская", "3-я Маккавейская", "2-я Ездры", "Матфей", "Марк", "Лука", "Иоанн", "Деяния",
        "Иаков", "1-е Петра", "2-е Петра", "1-е Иоанна", "2-е Иоанна", "3-е Иоанна", "Иуда", "Римлянам", 
        "1-е Коринфянам", "2-е Коринфянам", "Галатам", "Ефесянам", "Филиппийцам", "Колоссянам", "1-е Фессалоникийцам",
        "2-е Фессалоникийцам", "1-е Тимофею", "2-е Тимофею", "Титу", "Филимону", "Евреям", "Откровение Иоанна"
    };

    private static readonly string[] ValidTranslationAbbreviations =
    {
        "ASV", "KJV", "RusSynodal"
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