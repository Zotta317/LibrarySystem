namespace LibrarySystem.DTO
{
    public class BookDTO
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }
        public int AvailableBooks { get; set; }
        public int PageCount { get; set; }
    }
}
