using LibrarySystem.DTO;
using LibrarySystem.Models;

namespace LibrarySystem.Interface
{
    public interface IProfileRepository
    {
        Task<IEnumerable<Profile>> GetAllProfiles();
        Task<Profile> GetProfileById(Guid id);
        Task<bool> CreateProfile(ProfilePostDTO profileDTO);
        Task<bool> UpdateProfile(ProfilePutDTO profileDTO);
        Task<bool> DeleteProfile(Guid id);
    }
}
