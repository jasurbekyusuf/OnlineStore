namespace OnlineStore.Domain.Common.Responses
{
    public class ErrorCodeException : Exception
    {
        public int HttpStatusCode { get; set; } = 500;

        public ErrorCodeException(string message) : base(message)
        {

        }
        public ErrorCodeException(string message, int httpStatusCode) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}

