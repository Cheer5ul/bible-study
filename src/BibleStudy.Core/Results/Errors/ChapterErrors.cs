namespace BibleStudy.Core.Results.Errors;

public static class ChapterErrors
{
    public static Error NotFound(string book, int chapter) =>
        new Error("Chapter.NotFound", 
            $"Chapter {chapter} was not found.");
}