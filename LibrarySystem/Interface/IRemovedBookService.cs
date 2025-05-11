using LibrarySystem.DTO;
using LibrarySystem.Models;

namespace LibrarySystem.Interface
{
    public interface IRemovedBookService
    {
        Task<IEnumerable<RemovedBookDTO>> GetAllRemovedBooksAsync();
        Task<bool> RemoveBookAsync(Guid bookId, string reason);
        Task<bool> RestoreBookAsync(Guid bookId);
    }
}
