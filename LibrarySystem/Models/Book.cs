using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LibrarySystem.Models
{
    public class Book
    {
        [Key]
        public Guid ID { get; set; }

        public string Title { get; set; }   

        public string Author { get; set; }

        public int Quantity { get; set; }

        public int AvailableBooks { get; set; }
        public int PageCount { get; set; }

        public ICollection<BookRecord> BookRecords { get; set; }
        public RemovedBook? RemovedBooks { get; set; }
    }
}
