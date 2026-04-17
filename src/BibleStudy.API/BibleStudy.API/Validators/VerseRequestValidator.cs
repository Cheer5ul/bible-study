using BibleStudy.API.Contracts.Verse;
using FluentValidation;

namespace BibleStudy.API.Validators;

public class VerseRequestValidator : AbstractValidator<VerseRequest>
{
    public VerseRequestValidator()
    {
        RuleFor(x => x.TranslationAbbrev)
            .NotEmpty()
            .MaximumLength(15);

        RuleFor(x => x.Chapter)
            .GreaterThan(0);
        
        RuleFor(x => x.VerseNumber)
            .GreaterThan(0);
    }
}