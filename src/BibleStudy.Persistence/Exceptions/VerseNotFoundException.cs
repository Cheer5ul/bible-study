namespace BibleStudy.Persistence.Exceptions;

public class VerseNotFoundException : Exception
{
    public VerseNotFoundException(string message) : base(message)
    {
    }
}