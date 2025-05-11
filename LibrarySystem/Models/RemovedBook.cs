using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    public class RemovedBook
    {
        [Key, ForeignKey("Book")]
        public Guid ID { get; set; } 

        public int Quantity { get; set; }
        public int LostBook { get; set; }
        public int WornOutBook { get; set; }
        public DateTime DeletedAt { get; set; }

        public Book Book { get; set; }
    }
}
