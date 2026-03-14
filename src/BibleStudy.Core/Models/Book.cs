namespace BibleStudy.Core.Models;

public class Book
{
    private Book() {} // For EF Core
    
    public int Id { get; private set; }
    
    ///<summary>The translation this book belongs to e.g. "KJV", "NIV" </summary>
    public Translation Translation { get; private set; }

    /// <summary>Full book name e.g. "Genesis", "Revelation"</summary>
    public string Name  { get; private set; }
    
}