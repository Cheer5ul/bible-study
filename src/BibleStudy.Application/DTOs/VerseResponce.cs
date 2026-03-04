namespace BibleStudy.Application.DTOs;

public class VerseResponse
{
    public int Id { get; private set; }
    public int BookId { get; private set; }
    public int Chapter { get; private set; }
    public int VerseNumber { get; private set; }
    public string Text { get; private set; }
}