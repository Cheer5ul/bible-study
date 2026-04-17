using FluentValidation;

namespace BibleStudy.API.Validators;

public class TranslationRequestValidator : AbstractValidator<string>
{
    public TranslationRequestValidator()
    {
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("Translation abbreviation cannot be empty.");
    }
}