using System.ComponentModel.DataAnnotations;

namespace BibleStudy.API.Contracts.Verse;

public class VerseRequest
{
    public required string TranslationAbbrev { get; set; }
    public required string Book { get; set; }
    public int Chapter { get; set; }
    public int VerseNumber { get; set; }
    
}