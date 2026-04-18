namespace BibleStudy.Core.Results.Errors;

public static class ChapterErrors
{
    public const string ChapterNotFound = "Chapter.NotFound";
    public static Error NotFound(string book, int chapter) =>
        new Error(ChapterNotFound,
            $"Chapter {chapter} was not found.");
    
    public const string CouldNotCoundChapters = "Chapter.CouldNotCoundChapters";
    public static Error CouldNotCountChapters(string translationAbbrev, string book) =>
        new Error(ChapterNotFound,
            $"Could not count chapters for book {book} with translation {translationAbbrev}.");
}