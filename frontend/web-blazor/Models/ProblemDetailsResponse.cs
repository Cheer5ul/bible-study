public class ProblemDetailsResponse
{
    public string? Type  { get; init; }
    public string? Title { get; init; }
    public int? Status { get; init; }
    public string? Instance { get; init; }
    public string? TraceId { get; init; }
    public string? RequestId { get; init; }
    public List<ErrorResponse>? Errors { get; init; }
}