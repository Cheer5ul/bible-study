namespace BibleStudy.Core.Models;

public class Translation
{
    private Translation() {}

    public string TranslationAbbrev { get; private set; } // (ASV, KJV)
    public string Title { get; private set; }
    public string Licence { get; private set; }
    
}