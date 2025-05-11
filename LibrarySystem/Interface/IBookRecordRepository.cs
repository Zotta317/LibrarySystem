using LibrarySystem.DTO;
using LibrarySystem.Models;

namespace LibrarySystem.Interface
{
    public interface IBookRecordRepository
    {
        Task<IEnumerable<BookRecord>> GetAllBookRecords();
        Task<BookRecord?> GetById(Guid id);
        Task CreateBookRecord(BookRecordPostDTO bookRecord);
        Task UpdateBookRecord(BookRecord bookRecord);
        Task DeleteBookRecord(Guid id);
    }
}
