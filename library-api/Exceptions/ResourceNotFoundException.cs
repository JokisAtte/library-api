using System;

namespace LibraryApi.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public int StatusCode { get; }
        public ResourceNotFoundException(string message) : base(message)
        {
        }

        public ResourceNotFoundException(string message, int statusCode) : base(message)
        {
            this.StatusCode = statusCode;
        }
        public ResourceNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}