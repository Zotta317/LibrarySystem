using Humanizer;
using LibrarySystem.Data;
using LibrarySystem.DTO;
using LibrarySystem.Interface;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly LibrarySystemDbContext _context;

        public ProfileRepository(LibrarySystemDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Profile>> GetAllProfiles()
        {
            return await _context.Profiles.ToListAsync();
        }

        public async Task<Profile> GetProfileById(Guid id)
        {
            return await _context.Profiles.FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<bool> CreateProfile(ProfilePostDTO profileDTO)
        {
            var profile = new Profile
            {
                ID = Guid.NewGuid(),
                FirstName = profileDTO.FirstName,
                SecondName = profileDTO.SecondName,
                Email = profileDTO.Email,
                RegistrationDate = DateTime.UtcNow,
                isAdmin = false
            };

            _context.Profiles.Add(profile);

            return Save();
        }

        public async Task<bool> UpdateProfile(ProfilePutDTO profileDTO)
        {
            var profile = await _context.Profiles.FindAsync(profileDTO.ID);

            profile.FirstName = profileDTO.FirstName;
            profile.SecondName = profileDTO.SecondName;
            profile.Email = profileDTO.Email;
            _context.Profiles.Update(profile);
            return Save();
        }

        public async Task<bool> DeleteProfile(Guid id)
        {
            var profile = await GetProfileById(id);
            if (profile == null) return false;

            _context.Profiles.Remove(profile);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
