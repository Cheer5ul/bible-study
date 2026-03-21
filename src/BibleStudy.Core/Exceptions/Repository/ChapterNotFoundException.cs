namespace BibleStudy.Core.Exceptions.Repository;

public class ChapterNotFoundException : Exception
{
    public ChapterNotFoundException(string message) : base(message)
    {
    }
}