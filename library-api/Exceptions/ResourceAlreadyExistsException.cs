using System;

namespace LibraryApi.Exceptions
{
    public class ResourceAlreadyExistsException : Exception
    {
        public int StatusCode { get; }
        public ResourceAlreadyExistsException()
        {
        }

        public ResourceAlreadyExistsException(string message) : base(message)
        {
        }

        public ResourceAlreadyExistsException(string message, int statusCode) : base(message)
        {
            this.StatusCode = statusCode;
        }

        public ResourceAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
            this.StatusCode = StatusCode;
        }
    }
}