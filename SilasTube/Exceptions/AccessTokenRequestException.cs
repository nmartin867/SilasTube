namespace SilasTube.Exceptions
{
    public class AccessTokenRequestException : Exception
    {
        public AccessTokenRequestException()
        {}

        public AccessTokenRequestException(string? message) : base(message)
        {}

        public AccessTokenRequestException(string message, Exception innerException) : base(message, innerException)
        {}
    }
}
