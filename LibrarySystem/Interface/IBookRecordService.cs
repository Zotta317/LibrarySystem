using LibrarySystem.DTO;
using LibrarySystem.Models;

namespace LibrarySystem.Interface
{
    public interface IBookRecordService
    {
        Task<IEnumerable<BookRecordDTO>> GetAllBookRecords();
        Task<BookRecordDTO?> GetBookRecordById(Guid id);
        Task LendBook(BookRecordPostDTO bookRecord);
        Task ReturnBook(Guid id);
        Task DeleteBookRecord(Guid id);
    }
}
