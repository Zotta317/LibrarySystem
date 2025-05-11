using LibrarySystem.DTO;
using LibrarySystem.Interface;
using LibrarySystem.Models;

namespace LibrarySystem.Service
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<IEnumerable<Profile>> GetAllProfiles()
        {
            return await _profileRepository.GetAllProfiles();
        }

        public async Task<Profile> GetProfileById(Guid id)
        {
            return await _profileRepository.GetProfileById(id);
        }

        public async Task<bool> CreateProfile(ProfilePostDTO profileDTO)
        {
            return await _profileRepository.CreateProfile(profileDTO);
        }

        public async Task<bool> UpdateProfile(ProfilePutDTO profileDTO)
        {
            return await _profileRepository.UpdateProfile(profileDTO);
        }

        public async Task<bool> DeleteProfile(Guid id)
        {
            return await _profileRepository.DeleteProfile(id);
        }
    }
}
