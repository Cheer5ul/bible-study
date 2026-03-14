namespace BibleStudy.Core.Models;

public class Verse
{
    private Verse() {}

    public int Id { get; private set; }
    public int BookId { get; private set; }
    public int Chapter { get; private set; }
    public int VerseNumber { get; private set; }
    public string Text { get; private set; }
    
    public static Verse AssembleVerseWithoutVerseId(int bookId, int chapter, int verseNumber, string text)
    {
        var verse = new Verse()
        {
            BookId = bookId,
            Chapter = chapter,
            VerseNumber = verseNumber,
            Text = text
        };

        return verse;
    }
    
}