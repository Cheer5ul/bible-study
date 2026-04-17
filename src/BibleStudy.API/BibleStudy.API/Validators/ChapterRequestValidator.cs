using BibleStudy.API.Contracts.Verse;
using BibleStudy.Core.Results.Errors;
using FluentValidation;

namespace BibleStudy.API.Validators;

public class ChapterRequestValidator : AbstractValidator<ChapterRequest>
{
    public ChapterRequestValidator()
    {
        RuleFor(x => x.TranslationAbbrev)
            .NotEmpty()
            .Must(t => Core.Constants.BibleTranslations.All.Contains(t))
            .WithErrorCode(TranslationAbbrevErrors.NotFoundCode)
            .WithMessage("Translation abbreviation '{PropertyValue}' is not a valid translation abbreviation name.");

        RuleFor(x => x.Chapter)
            .GreaterThan(0);
    }
}