namespace LibrarySystem.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException() { }

        public ItemNotFoundException(string? message)
            : base(message) { }

        public ItemNotFoundException(string? message, Exception? innerException)
            : base(message, innerException) { }

        public ItemNotFoundException(Guid itemId, string itemName)
            : base(FormattableString.Invariant($"Item '{itemName}' with ID '{itemId}' was not found.")) { }
    }
}
