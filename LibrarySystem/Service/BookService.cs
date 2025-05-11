using LibrarySystem.DTO;
using LibrarySystem.Exceptions;
using LibrarySystem.Interface;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookDTO>> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooks();

            var bookDTOs = books.Select(book => new BookDTO
            {
                ID = book.ID,
                Title = book.Title,
                Author = book.Author,
                Quantity = book.Quantity,
                AvailableBooks = book.AvailableBooks,
                PageCount = book.PageCount
            }).ToList();

            return bookDTOs;
        }

        public async Task<BookDTO> GetBookById(Guid bookId)
        {
            var book = await _bookRepository.GetBookById(bookId);
            if (book == null)
            {
                throw new ItemNotFoundException(bookId, "Book");
            }

            var bookDTO = new BookDTO
            {
                ID = book.ID,
                Title = book.Title,
                Author = book.Author,
                Quantity = book.Quantity,
                AvailableBooks = book.AvailableBooks,
                PageCount = book.PageCount
            };

            return bookDTO;
        }

        public async Task<Book> AddBook(BookPostDTO bookPostDTO)
        {
            return _bookRepository.AddBook(bookPostDTO);
        }

        public async Task<bool> UpdateBook(BookDTO bookDTO)
        {
            return _bookRepository.UpdateBook(bookDTO);
        }

        public async Task<bool> DeleteBook(Guid id)
        {
            var book = await _bookRepository.GetBookById(id);
            if (book == null)
                throw new ItemNotFoundException(id, "Book");
            return _bookRepository.DeleteBook(book);
        }

        public async Task<PaginatedList<BookDTO>> GetBooks(int pageIndex, int pageSize)
        {

            var booksPaginated = await _bookRepository.GetBooksPaginated(pageIndex, pageSize);


            var bookDTOs = booksPaginated.Select(book => new BookDTO
            {
                ID = book.ID,
                Title = book.Title,
                Author = book.Author,
                Quantity = book.Quantity,
                AvailableBooks = book.AvailableBooks,
                PageCount = book.PageCount
            }).ToList();


            var paginatedBookDTOs = new PaginatedList<BookDTO>(
                bookDTOs,
                booksPaginated.TotalCount,
                booksPaginated.PageIndex,
                booksPaginated.TotalPages
            );

            return paginatedBookDTOs;
        }

        public async Task<IEnumerable<BookDTO>> GetSortedBooks(string sortFilter, string searchFilter)
        {

            IQueryable<Book> query = _bookRepository.GetFilteredAndSortedBooks(sortFilter, searchFilter);

            var bookDTOs = await query.Select(book => new BookDTO
            {
                ID = book.ID,
                Title = book.Title,
                Author = book.Author,
                Quantity = book.Quantity,
                AvailableBooks = book.AvailableBooks,
                PageCount = book.PageCount
            }).ToListAsync();

            return bookDTOs;
        }
    }
}
