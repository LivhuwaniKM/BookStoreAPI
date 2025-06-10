using BSCore;
using BSDomain;
using BSServices;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController(IBookService _bookService) : BaseController
    {
        [HttpGet("list")]
        public async Task<ActionResult<IList<Book>>> GetAllBooksAsync()
        {
            var response = await Task.Run(() => _bookService.GetAllBooks());

            return response != null ? Ok(response) : NotFound("no data found.");
        }

        [HttpGet("get/{isbn}")]
        public async Task<ActionResult<Book>> GetBookByIsbnAsync(string isbn)
        {
            var response = await Task.Run(() => _bookService.GetBookByIsbn(isbn));

            return response != null ? Ok(response) : NotFound("no data found.");
        }

        [HttpPost("create")]
        public async Task<ActionResult<Book>> AddBookAsync([FromBody] Book book)
        {
            var response = await Task.Run(() => _bookService.AddBook(book));

            return response != null ? Ok(response) : BadRequest("null object reference.");
        }

        [HttpPut("update/{isbn}")]
        public async Task<ActionResult<Book>> UpdateBookAsync(string isbn, [FromBody] Book book)
        {
            if (string.IsNullOrEmpty(isbn) || book == null)
                return BadRequest("null object reference.");

            var response = await Task.Run(() => _bookService.UpdateBook(book));

            return response != null ? Ok(response) : BadRequest("null object reference.");
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteBookAsync(int id)
        {
            if (id <= 0)
                return BadRequest("null object reference.");

            var response = await Task.Run(() => _bookService.DeleteBook(id));

            return response != null ? Ok(response) : BadRequest("null object reference.");
        }
    }
}
