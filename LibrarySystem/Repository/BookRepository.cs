using LibrarySystem.Data;
using LibrarySystem.DTO;
using LibrarySystem.Interface;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibrarySystemDbContext _context;

        public BookRepository(LibrarySystemDbContext context)
        {
            _context = context;
        }

        public Book AddBook(BookPostDTO bookPostDTO)
        {
            var book = new Book
            {
                ID = Guid.NewGuid(),
                Title = bookPostDTO.Title,
                Author = bookPostDTO.Author,
                Quantity = bookPostDTO.Quantity,
                AvailableBooks = bookPostDTO.AvailableBooks,
                PageCount = bookPostDTO.PageCount
            };

            _context.Add(book);
            var success = Save();
            return success ? book : null;
        }

        public bool UpdateBook(BookDTO bookDTO)
        {
            var book = _context.Books.FirstOrDefault(b => b.ID == bookDTO.ID);

            if (book == null)
            {
                return false; 
            }

            book.Title = bookDTO.Title;
            book.Author = bookDTO.Author;
            book.Quantity = bookDTO.Quantity;
            book.AvailableBooks = bookDTO.AvailableBooks;
            book.PageCount = bookDTO.PageCount;

            _context.Update(book);

            return Save();
        }
        public bool LendBook(Book book)
        {
            _context.Update(book);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public async Task<Book> GetBookById(Guid bookId)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.ID == bookId);
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<PaginatedList<Book>> GetBooksPaginated(int pageIndex, int pageSize)
        {
            return await PaginatedList<Book>.CreateAsync(
                _context.Books.AsQueryable(),
                pageIndex,
                pageSize
            );
        }


        private IQueryable<Book> ApplySearchFilter(IQueryable<Book> query, string searchFilter, string sortFilter)
        {
            if (!string.IsNullOrEmpty(searchFilter))
            {
                if (sortFilter?.ToLower() == "author")
                {
                    query = query.Where(b => b.Author.Contains(searchFilter));
                }
                else
                {
                    query = query.Where(b => b.Title.Contains(searchFilter));
                }
            }

            return query;
        }


        private IQueryable<Book> ApplySortFilter(IQueryable<Book> query, string sortFilter)
        {
            sortFilter = sortFilter?.ToLower() ?? "";

            query = sortFilter switch
            {
                "author" => query.OrderBy(b => b.Author),
                "pagecount" => query.OrderBy(b => b.PageCount),
                _ => query.OrderBy(b => b.Title) 
            };

            return query;
        }

       
        public IQueryable<Book> GetFilteredAndSortedBooks(string sortFilter, string searchFilter)
        {
            IQueryable<Book> query = _context.Books.AsQueryable();

            
            query = ApplySearchFilter(query, searchFilter, sortFilter);

            
            query = ApplySortFilter(query, sortFilter);

            return query;
        }

        
        public bool DeleteBook(Book book)
        {
            _context.Remove(book);
            return Save();
        }
    }
}
