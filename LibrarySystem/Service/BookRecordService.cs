using LibrarySystem.DTO;
using LibrarySystem.Interface;
using LibrarySystem.Models;

namespace LibrarySystem.Service
{
    public class BookRecordService : IBookRecordService
    {
        private readonly IBookRecordRepository _recordRepository;
        private readonly IBookRepository _bookRepository;

        public BookRecordService(IBookRecordRepository recordRepository, IBookRepository bookRepository)
        {
            _recordRepository = recordRepository;
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookRecordDTO>> GetAllBookRecords()
        {
            var records = await _recordRepository.GetAllBookRecords();

            var recordsDTO = records.Select(br => new BookRecordDTO
            {
                ID = br.ID,
                BookID = br.BookID,
                BookTitle = br.Book.Title,  
                ProfileID = br.ProfileID,
                ProfileEmail = br.Profile.Email, 
                BorrowedStartDate = br.BorrowedStartDate,
                BorrowedEndDate = br.BorrowedEndDate,
                ReturnedDate = br.ReturnedDate,
                IsReturned = br.IsReturned
            }).ToList();

            return recordsDTO;  
        }

        public async Task<BookRecordDTO?> GetBookRecordById(Guid id)
        {
 
            var bookRecord = await _recordRepository.GetById(id);

            if (bookRecord == null)
            {
                return null;
            }

            var bookRecordDTO = new BookRecordDTO
            {
                ID = bookRecord.ID,
                BookID = bookRecord.BookID,
                BookTitle = bookRecord.Book.Title,
                ProfileID = bookRecord.ProfileID,
                ProfileEmail = bookRecord.Profile.Email, 
                BorrowedStartDate = bookRecord.BorrowedStartDate,
                BorrowedEndDate = bookRecord.BorrowedEndDate,
                ReturnedDate = bookRecord.ReturnedDate,
                IsReturned = bookRecord.IsReturned
            };

            return bookRecordDTO;
        }

        public async Task LendBook(BookRecordPostDTO bookRecord)
        {
            var book = await _bookRepository.GetBookById(bookRecord.BookID);

            if (book != null && book.AvailableBooks > 0)
            {
                book.AvailableBooks -= 1;
                _bookRepository.LendBook(book);

                await _recordRepository.CreateBookRecord(bookRecord);
            }
            else
            {
                throw new InvalidOperationException("Book is not available for lending.");
            }
        }

        public async Task ReturnBook(Guid id)
        {
            var record = await _recordRepository.GetById(id);
            if (record != null && !record.IsReturned)
            {
                record.ReturnedDate = DateTime.Now;
                record.IsReturned = true;

                var book = await _bookRepository.GetBookById(record.BookID);
                if (book != null)
                {
                    book.AvailableBooks += 1;
                    _bookRepository.LendBook(book); 
                }

                await _recordRepository.UpdateBookRecord(record);
            }
        }

        public async Task DeleteBookRecord(Guid id)
        {
            await _recordRepository.DeleteBookRecord(id);
        }
    }
}
