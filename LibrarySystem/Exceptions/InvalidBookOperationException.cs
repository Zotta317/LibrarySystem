namespace LibrarySystem.Exceptions
{
    public class InvalidBookOperationException : Exception
    {
        public InvalidBookOperationException() { }

        public InvalidBookOperationException(string? message)
            : base(message) { }

        public InvalidBookOperationException(string? message, Exception? innerException)
            : base(message, innerException) { }

        public InvalidBookOperationException(Guid bookId, string reason)
            : base(FormattableString.Invariant($"Invalid operation on Book with ID '{bookId}': {reason}")) { }
    }
}
