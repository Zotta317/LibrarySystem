namespace LibrarySystem.DTO
{
    public class BookRecordDTO
    {
        public Guid ID { get; set; }
        public Guid BookID { get; set; }
        public string BookTitle { get; set; } 
        public Guid ProfileID { get; set; }
        public string ProfileEmail { get; set; } 
        public DateTime BorrowedStartDate { get; set; }
        public DateTime BorrowedEndDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public bool IsReturned { get; set; }
    }
}
