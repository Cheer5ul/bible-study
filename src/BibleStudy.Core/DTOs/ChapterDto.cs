namespace BibleStudy.Core.DTOs;

public record ChapterDto(
    string TranslationAbbrev,
    string BookName,
    int Chapter,
    IReadOnlyList<VerseLineDto> Verses);