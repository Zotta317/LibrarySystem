using LibrarySystem.DTO;
using LibrarySystem.Interface;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfilesController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profile>>> GetAll()
        {
            var profiles = await _profileService.GetAllProfiles();
            return Ok(profiles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profile>> GetProfileById(Guid id)
        {
            var profile = await _profileService.GetProfileById(id);
            if (profile == null)
                return NotFound($"Profile with ID {id} not found.");

            return Ok(profile);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProfile(ProfilePostDTO profileDTO)
        {
            var result = await _profileService.CreateProfile(profileDTO);
            if (result)
                return CreatedAtAction(nameof(GetProfileById), profileDTO);

            return BadRequest("Failed to create profile.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProfile(Guid id, ProfilePutDTO profileDTO)
        {
            if (id != profileDTO.ID)
                return BadRequest("ID mismatch.");

            var result = await _profileService.UpdateProfile(profileDTO);
            if (result)
                return NoContent();

            return NotFound("Profile not found or update failed.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProfile(Guid id)
        {
            var result = await _profileService.DeleteProfile(id);
            if (result)
                return NoContent();

            return NotFound("Profile not found or delete failed.");
        }
    }
}
