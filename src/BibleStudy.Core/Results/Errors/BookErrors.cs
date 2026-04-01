namespace BibleStudy.Core.Results.Errors;

public static class BookErrors
{
    public const string NotFoundCode = "Book.NotFound";
    public static Error NotFound(string bookName) => new Error(
        NotFoundCode,
        $"Book {bookName} was not found.");
}