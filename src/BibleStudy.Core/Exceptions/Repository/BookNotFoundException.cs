namespace BibleStudy.Core.Exceptions.Repository;

public class BookNotFoundException : Exception
{
    public BookNotFoundException(string message) : base(message) { }
}