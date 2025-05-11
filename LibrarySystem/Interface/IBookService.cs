using LibrarySystem.DTO;
using LibrarySystem.Models;

namespace LibrarySystem.Interface
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAllBooks();
        Task<BookDTO> GetBookById(Guid bookId);
        Task<Book> AddBook(BookPostDTO bookPostDTO);
        Task<bool> UpdateBook(BookDTO bookDTO);
        Task<bool> DeleteBook(Guid id);
        Task<PaginatedList<BookDTO>> GetBooks(int pageIndex, int pageSize);

        Task<IEnumerable<BookDTO>> GetSortedBooks(string sortFilter, string searchFilter);
    }
}
