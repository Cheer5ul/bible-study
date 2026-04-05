public class ProblemDetailsResponse
{
    public string? Type  { get; set; }
    public string? Title { get; set; }
    public int? Status { get; set; }
    public string? Instance { get; set; }
    public string? TraceId { get; set; }
    public string? RequestId { get; set; }
    public List<ErrorResponse>? Errors { get; set; }
}