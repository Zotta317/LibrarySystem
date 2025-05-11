using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class Profile
    {
        [Key]
        public Guid ID { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool isAdmin { get; set; }
        public ICollection<BookRecord> BookRecords { get; set; }

    }
}
