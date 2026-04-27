
using System.Net.Http.Json;
using System.Text.Json;

public class ChapterApiClient
{
    private readonly HttpClient _httpClient;
    
    public ChapterApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<(ChapterDto? chapter, ProblemDetailsResponse?  problemDetailsResponse)> GetChapterAsync(
        string? translationAbbr, 
        string? bookName, 
        int? chapterNumber)
    {
        var response = await _httpClient.GetAsync
            ($"http://localhost:5246/api/Chapter/chapter?TranslationAbbrev={translationAbbr}&Book={bookName}&Chapter={chapterNumber}");

        if (response.IsSuccessStatusCode)
        {
            var chapter = await response.Content.ReadFromJsonAsync<ChapterDto>(
                new JsonSerializerOptions() {PropertyNameCaseInsensitive = true} );
            return (chapter, null);
        }
        else
        {
            var errorResponse = await response.Content.ReadFromJsonAsync<ProblemDetailsResponse>(
                new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
            return (null, errorResponse);
        }
    }
}
