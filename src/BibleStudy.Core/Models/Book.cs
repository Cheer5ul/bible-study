namespace BibleStudy.Core.Models;

public class Book
{
    private Book() {} // For EF Core
    
    public int Id { get; private set; }
    public Translation Translation { get; private set; }
    public string Name  { get; private set; }
    
}