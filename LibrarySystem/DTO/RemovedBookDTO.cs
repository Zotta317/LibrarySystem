namespace LibrarySystem.DTO
{
    public class RemovedBookDTO
    {
        internal string BookTitle;

        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public int LostBook { get; set; }
        public int WornOutBook { get; set; }
        public DateTime DeletedAt { get; set; }
        public Guid BookId { get; set; }
    }
}
