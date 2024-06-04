namespace Forum.API
{
    public class ApiResponse
    {
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
        public object? Result { get; set; }
        public int StatusCode { get; set; }
    }
}
