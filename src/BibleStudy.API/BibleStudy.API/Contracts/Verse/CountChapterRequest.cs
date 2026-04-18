namespace BibleStudy.API.Contracts.Verse;

public record CountChapterRequest(
    string TranslationAbbrev,
    string Book);