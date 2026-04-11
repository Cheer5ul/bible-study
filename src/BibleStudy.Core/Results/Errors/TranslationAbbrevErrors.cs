namespace BibleStudy.Core.Results.Errors;

public static class TranslationAbbrevErrors
{
    public const string NotFoundCode = "TranslationAbbreviation.NotFound";
    public static Error NotFound(string translationAbbrev) => new Error(
        NotFoundCode, 
        $"Translation Abbreviation {translationAbbrev} was not found.");
}