namespace SilasTube.Models
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T? Value { get; }
        public string? Error { get; }

        protected Result(bool isSuccess, T? value, string? error = null)
        {
            IsSuccess = isSuccess;
            Value = value;
            Error = error;
        }

        public static Result<T> Success(T value) => new Result<T>(true, value);
        public static Result<T> Failure(Exception exception) => new Result<T>(false, default, exception.Message);
    }
}
