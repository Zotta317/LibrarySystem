using LibrarySystem.Models;

namespace LibrarySystem.Interface
{
    public interface IRemovedBookRepository
    {
        Task<IEnumerable<RemovedBook>> GetAllAsync();
        Task<RemovedBook?> GetByIdAsync(Guid id);
        Task AddAsync(RemovedBook removedBook);
        Task UpdateAsync(RemovedBook removedBook);
        Task DeleteAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
