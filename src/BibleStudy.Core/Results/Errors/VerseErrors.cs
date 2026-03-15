namespace BibleStudy.Core.Results.Errors;

public static class VerseErrors
{
    public static Error NotFound(string book, int chapter, int verseNumber) => new Error(
        "Verse.NotFound",
        $"Verse {book} {chapter}:{verseNumber} was not found.");
}