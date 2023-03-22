namespace Future_Fashion_API.exceptions
{
    public class AppException : Exception
    {
        public List<string> validMessages { get; }

        public AppException() { }

        public AppException(string message)
            : base(message) { }

        public AppException(string message, Exception inner)
            : base(message, inner) { }

        public AppException(List<string> validMessages)
        {
            this.validMessages = validMessages;
        }
    }
}
