namespace BibleStudy.Core.DTOs;

public record VerseDto(string BookName, int Chapter, int VerseNumber, string Text);