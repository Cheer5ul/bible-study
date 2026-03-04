namespace BibleStudy.Application.DTOs;

public class ChapterResponce
{
    public int ChapterNumber { get; set; }
    public string BookName { get; set; }
    public string TranslationAbbrev { get; set; }
    public List<VerseResponse> Verses { get; set; }
}