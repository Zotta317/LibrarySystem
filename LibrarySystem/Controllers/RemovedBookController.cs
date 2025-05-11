using LibrarySystem.Interface;
using LibrarySystem.Service;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RemovedBookController : ControllerBase
    {
        private readonly IRemovedBookService _service;

        public RemovedBookController(IRemovedBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllRemovedBooksAsync();
            return Ok(result);
        }

        [HttpPost("remove/{bookId}")]
        public async Task<IActionResult> Remove(Guid bookId, [FromQuery] string reason)
        {
            var result = await _service.RemoveBookAsync(bookId, reason);
            return result ? Ok("Book removed.") : BadRequest("Could not remove book.");
        }

        [HttpPost("restore/{bookId}")]
        public async Task<IActionResult> Restore(Guid bookId)
        {
            var result = await _service.RestoreBookAsync(bookId);
            return result ? Ok("Book restored.") : BadRequest("Could not restore book.");
        }
    }
}
