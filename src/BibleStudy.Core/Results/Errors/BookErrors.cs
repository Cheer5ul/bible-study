namespace BibleStudy.Core.Results.Errors;

public static class BookErrors
{
    public static Error NotFound(string bookName) => new Error(
        "Book.NotFound",
        $"Book {bookName} was not found.");
}