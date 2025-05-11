using LibrarySystem.DTO;
using LibrarySystem.Exceptions;
using LibrarySystem.Interface;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace LibrarySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetAllBooks()
        {
            var books = await _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBookById(Guid id)
        {
            try
            {
                var bookDTO = await _bookService.GetBookById(id);
                return Ok(bookDTO);
            }
            catch (ItemNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult> AddBook( BookPostDTO bookPostDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var book = await _bookService.AddBook(bookPostDTO);

            if (book != null)
                return CreatedAtAction(nameof(GetBookById), new { id = book.ID }, book);
            return BadRequest("Failed to create book.");
        }


        [HttpPut]
        public async Task<ActionResult> UpdateBook(BookDTO bookDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _bookService.UpdateBook(bookDTO);
            if (result)
                return NoContent();

            return NotFound("Book not found or update failed.");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(Guid id)
        {
            try
            {
                var result = await _bookService.DeleteBook(id);
                return result ? NoContent() : NotFound();
            }
            catch (ItemNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<PaginatedList<BookDTO>>> GetBooks(int pageIndex, int pageSize)
        {
            var books = await _bookService.GetBooks(pageIndex, pageSize);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        [HttpGet("sorted")]
        public async Task<IActionResult> GetSortedBooks(string sortFilter = "title", string? searchFilter = "")
        {
            var books = await _bookService.GetSortedBooks(sortFilter, searchFilter);
            return Ok(books);
        }
    }
}
