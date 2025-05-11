using LibrarySystem.DTO;
using LibrarySystem.Exceptions;
using LibrarySystem.Interface;
using LibrarySystem.Models;

namespace LibrarySystem.Service
{
    public class RemovedBookService : IRemovedBookService
    {
        private readonly IRemovedBookRepository _removedRepo;
        private readonly IBookRepository _bookRepo;

        public RemovedBookService(IRemovedBookRepository removedRepo, IBookRepository bookRepo)
        {
            _removedRepo = removedRepo;
            _bookRepo = bookRepo;
        }

        public async Task<IEnumerable<RemovedBookDTO>> GetAllRemovedBooksAsync()
        {
            var removedBooks = await _removedRepo.GetAllAsync();
            return removedBooks.Select(r => new RemovedBookDTO
            {
                Id = r.ID,
                Quantity = r.Quantity,
                LostBook = r.LostBook,
                WornOutBook = r.WornOutBook,
                DeletedAt = r.DeletedAt,
                BookId = r.Book.ID,
                BookTitle = r.Book.Title
            });
        }

        public async Task<bool> RemoveBookAsync(Guid bookId, string reason)
        {
            var book = await _bookRepo.GetBookById(bookId)
                ?? throw new ItemNotFoundException(bookId, nameof(Book));

            if (book.AvailableBooks <= 0)
                throw new InvalidBookOperationException(bookId, "No available copies to remove.");

            book.AvailableBooks -= 1;
            book.Quantity -= 1;
            _bookRepo.LendBook(book);

            var removedBook = await _removedRepo.GetByIdAsync(bookId);
            if (removedBook == null)
            {
                removedBook = new RemovedBook
                {
                    ID = book.ID,
                    Book = book,
                    Quantity = 1,
                    LostBook = reason.ToLower() == "lost" ? 1 : 0,
                    WornOutBook = reason.ToLower() == "wornout" ? 1 : 0,
                    DeletedAt = DateTime.UtcNow
                };
                await _removedRepo.AddAsync(removedBook);
            }
            else
            {
                removedBook.Quantity += 1;
                if (reason.ToLower() == "lost")
                    removedBook.LostBook += 1;
                else if (reason.ToLower() == "wornout")
                    removedBook.WornOutBook += 1;

                removedBook.DeletedAt = DateTime.UtcNow;
                await _removedRepo.UpdateAsync(removedBook);
            }

            if (book.Quantity == 0)
                _bookRepo.DeleteBook(book);

            return true;
        }

        public async Task<bool> RestoreBookAsync(Guid bookId)
        {
            var removedBook = await _removedRepo.GetByIdAsync(bookId)
                ?? throw new ItemNotFoundException(bookId, nameof(RemovedBook));

            if (removedBook.Quantity == 0 || removedBook.LostBook == 0)
                throw new InvalidBookOperationException(bookId, "No available copies to remove.");

            var book = await _bookRepo.GetBookById(bookId)
                ?? throw new ItemNotFoundException(bookId, nameof(Book));

            removedBook.LostBook -= 1;
            removedBook.Quantity -= 1;

            book.Quantity += 1;
            book.AvailableBooks += 1;

            _bookRepo.LendBook(book);

            if (removedBook.Quantity == 0)
                await _removedRepo.DeleteAsync(bookId);
            else
                await _removedRepo.UpdateAsync(removedBook);

            return true;
        }
    }
}
