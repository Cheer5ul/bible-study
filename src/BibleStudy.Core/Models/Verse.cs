namespace BibleStudy.Core.Models;

public class Verse
{
    private Verse() {}

    public int Id { get; private set; }

    /// <summary>ID of the book</summary>
    public int BookId { get; private set; }
    /// <summary>Number of chapter</summary>
    public int Chapter { get; private set; }
    /// <summary>Number of verse</summary>
    public int VerseNumber { get; private set; }
    /// <summary>Text of scripture reference itself</summary>
    public string Text { get; private set; }
    ///<summary>The translation this book belongs to e.g. "KJV", "NIV" </summary>
    public string TranslationAbbrev { get; private set; }
}