using LibrarySystem.DTO;
using LibrarySystem.Models;

namespace LibrarySystem.Interface
{
    public interface IBookRepository
    {
        Book AddBook(BookPostDTO bookPostDTO);
        bool DeleteBook(Book book);
        bool UpdateBook(BookDTO bookDTO);
        bool LendBook(Book book);
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(Guid bookId);
        Task<PaginatedList<Book>> GetBooksPaginated(int pageIndex, int pageSize);
        IQueryable<Book> GetFilteredAndSortedBooks(string sortFilter, string searchFilter);
        bool Save();
    }

}

