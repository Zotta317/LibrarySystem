using LibrarySystem.DTO;
using LibrarySystem.Interface;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookRecordController : ControllerBase
    {
        private readonly IBookRecordService _bookRecordService;

        public BookRecordController(IBookRecordService bookRecordService)
        {
            _bookRecordService = bookRecordService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var records = await _bookRecordService.GetAllBookRecords();
            return Ok(records);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var record = await _bookRecordService.GetBookRecordById(id);
            if (record == null)
                return NotFound();

            return Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> LendBook( BookRecordPostDTO bookRecord)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _bookRecordService.LendBook(bookRecord);
            return CreatedAtAction(nameof(GetById), new { id = bookRecord.BookID }, bookRecord);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id)
        {
            await _bookRecordService.ReturnBook(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _bookRecordService.DeleteBookRecord(id);
            return NoContent();
        }
    }
}
