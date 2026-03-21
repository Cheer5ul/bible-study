namespace BibleStudy.API.Contracts.Verse;

public class ChapterRequest
{
    public required string TranslationAbbrev { get; set; }
    public required string Book { get; set; }
    public int Chapter { get; set; }
}