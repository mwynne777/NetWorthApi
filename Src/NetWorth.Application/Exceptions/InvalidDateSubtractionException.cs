using System;

namespace NetWorth.Application.Exceptions
{
    public class InvalidDateSubtractionException : Exception
    {
        const string badDatesMessage = "Cannot compute negative date difference.";
        public InvalidDateSubtractionException()
        {
        }

        public InvalidDateSubtractionException(string message)
            : base(String.Format(badDatesMessage, message))
        {
        }

        public InvalidDateSubtractionException(string message, Exception inner)
            : base(String.Format(badDatesMessage, message), inner)
        {
        }
    }
}