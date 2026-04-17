namespace BibleStudy.Core.Exceptions.Repository;

public class BookListIsEmpty : Exception
{
    public BookListIsEmpty(string message) : base(message) { }
}