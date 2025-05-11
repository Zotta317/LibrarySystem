using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class BookRecord
    {
        [Key]
        public Guid ID { get; set; }
        public Guid ProfileID { get; set; }
        public Profile Profile { get; set; }
        public Guid BookID { get; set; }
        public Book Book { get; set; }

        public DateTime BorrowedStartDate { get; set; }

        public DateTime BorrowedEndDate { get; set; }
        public DateTime? ReturnedDate { get; set; }  

        public bool IsReturned { get; set; }
    }
}
