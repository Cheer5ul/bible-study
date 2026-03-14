namespace BibleStudy.Core.Models;

public class Translation
{
    private Translation() {}
    
    ///<summary>The translation this book belongs to e.g. "KJV", "NIV"</summary>
    public string TranslationAbbrev { get; private set; }

    ///<summary>Full name of the translation e.g. "ASV: American Standard Version (1901)"</summary>
    public string Title { get; private set; }
    
    /// <summary> License of the translation </summary>
    public string License { get; private set; }
    
}