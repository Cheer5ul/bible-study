namespace BibleStudy.Core.Exceptions.Repository;

public class VerseNotFoundException : Exception
{
    public VerseNotFoundException(string message) : base(message)
    {
    }
}