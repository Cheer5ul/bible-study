namespace BibleStudy.Core.Results.Errors;

public static class VerseErrors
{
    public const string VerseNotFound = "Verse.NotFound";
    public static Error NotFound(string book, int chapter, int verseNumber) => new Error(
        VerseNotFound,
        $"Verse {book} {chapter}:{verseNumber} was not found.");
}