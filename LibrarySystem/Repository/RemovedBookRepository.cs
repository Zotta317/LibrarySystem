using LibrarySystem.Data;
using LibrarySystem.Interface;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repository
{
    public class RemovedBookRepository : IRemovedBookRepository
    {
        private readonly LibrarySystemDbContext _context;

        public RemovedBookRepository(LibrarySystemDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RemovedBook>> GetAllAsync()
        {
            return await _context.RemovedBooks.Include(r => r.Book).ToListAsync();
        }

        public async Task<RemovedBook?> GetByIdAsync(Guid id)
        {
            return await _context.RemovedBooks.Include(r => r.Book)
                                              .FirstOrDefaultAsync(r => r.ID == id);
        }

        public async Task AddAsync(RemovedBook removedBook)
        {
            _context.RemovedBooks.Add(removedBook);
            await SaveAsync();
        }

        public async Task UpdateAsync(RemovedBook removedBook)
        {
            _context.RemovedBooks.Update(removedBook);
            await SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.RemovedBooks.Remove(entity);
                await SaveAsync();
            }
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
