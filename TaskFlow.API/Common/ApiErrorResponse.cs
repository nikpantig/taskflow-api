namespace TaskFlow.API.Common
{
    public class ApiErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public IEnumerable<ApiValidationError>? Errors { get; set; }
    }

    public class ApiValidationError
    {
        public string Field { get; set; } = string.Empty;
        public string Error { get; set; } = string.Empty;
    }
}
