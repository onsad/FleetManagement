namespace FleetManagement.Shared
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public ApiError? Error { get; set; }

        public static ApiResponse<T> Success(T data) =>
            new() { Data = data, IsSuccess = true };

        public static ApiResponse<T> Failure(string message) =>
            new()
            {
                IsSuccess = false,
                Error = new ApiError { Message = message }
            };
    }

    public class ApiError
    {
        public string Message { get; set; } = string.Empty;
    }
}
