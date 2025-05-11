using Humanizer;
using LibrarySystem.Data;
using LibrarySystem.DTO;
using LibrarySystem.Interface;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repository
{
    public class BookRecordRepository : IBookRecordRepository
    {
        private readonly LibrarySystemDbContext _context;

        public BookRecordRepository(LibrarySystemDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookRecord>> GetAllBookRecords()
        {
            return await _context.BookRecords
                .Include(br => br.Book)
                .Include(br => br.Profile)
                .ToListAsync();
        }

        public async Task<BookRecord?> GetById(Guid id)
        {
            return await _context.BookRecords
                .Include(br => br.Book)
                .Include(br => br.Profile)
                .FirstOrDefaultAsync(br => br.ID == id);
        }

        public async Task CreateBookRecord(BookRecordPostDTO bookRecordDTO)
        {
            var bookRecord = new BookRecord
            {
                ID = Guid.NewGuid(),
                ProfileID = bookRecordDTO.ProfileID,
                BookID = bookRecordDTO.BookID,
                BorrowedStartDate = DateTime.UtcNow,
                BorrowedEndDate = DateTime.UtcNow.AddDays(14),
                ReturnedDate = null,
                IsReturned = false
            };
            _context.BookRecords.Add(bookRecord);
            await _context.SaveChangesAsync();
        }

        //not finished
        public async Task UpdateBookRecord(BookRecord bookRecord)
        {
            _context.BookRecords.Update(bookRecord);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookRecord(Guid id)
        {
            var record = await _context.BookRecords.FindAsync(id);
            if (record != null)
            {
                _context.BookRecords.Remove(record);
                await _context.SaveChangesAsync();
            }
        }
    }
}
