

using System.Net.Http.Json;
using System.Text.Json;

public class TranslationApiClient
{
    private readonly HttpClient _httpClient;
    
    public TranslationApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<(List<string>? books, ProblemDetailsResponse? problemDetails)> GetAllBookNamesAsync(
        string? translationAbbrev)
    {
        var response = await _httpClient.GetAsync(
            $"http://localhost:5246/api/Translation?translationAbbrev={translationAbbrev}");

        if (response.IsSuccessStatusCode)
        {
            var books = await response.Content.ReadFromJsonAsync<List<string>>(
                new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
            return (books, null);
        }
        else
        {
            var errorResponse = await response.Content.ReadFromJsonAsync<ProblemDetailsResponse>(
                new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
            return (null, errorResponse);
        }
    }
}