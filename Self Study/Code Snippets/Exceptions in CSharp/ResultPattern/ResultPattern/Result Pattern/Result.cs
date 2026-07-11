namespace ResultPattern.Result_Pattern
{
    public class Result <T>
    {
        public bool Success { get; }
        public T Value { get; }
        public string Message { get; }
        public string Error { get; }

        private Result(bool success, T value, string message, string error)
        {
            Success = success;
            Value = value;
            Error = error;
            Message = message;
        }

        public static Result<T> ResultSuccess (T value, string message = "Operation success") => new Result<T>(true, value, message, null);
        public static Result<T> ResultFailure(string error, string message = "Operation failed") => new Result<T>(false, default(T), message, error);
    }
}
