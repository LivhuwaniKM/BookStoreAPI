using BSCore;
using BSDomain;
using BSServices;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController(IBookService bookService) : CustomControllerBase
    {
        private readonly IBookService _bookService = bookService;

        [HttpGet("get/all")]
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

        [HttpGet("get/query")]
        public async Task<ActionResult> GetBookByIsbnAsync([FromQuery] Book book)
        {
            var response = await Task.Run(() => _bookService.GetBookByIsbn(book));

            return response != null ? Ok(response) : NotFound("no data found.");
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBookAsync([FromBody] Book book)
        {
            var response = await Task.Run(() => _bookService.AddBook(book));

            return response != null ? Ok(response) : BadRequest("null object reference.");
        }

        [HttpPut("{isbn}")]
        public async Task<ActionResult<Book>> UpdateBookAsync(string isbn, [FromBody] Book book)
        {
            if (string.IsNullOrEmpty(isbn) || book == null)
                return BadRequest("null object reference.");

            var response = await Task.Run(() => _bookService.UpdateBook(book));

            return response != null ? Ok(response) : BadRequest("null object reference.");
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBookAsync(Book book)
        {
            if (book == null)
                return BadRequest("null object reference.");

            var response = await Task.Run(() => _bookService.DeleteBook(book));

            return response != null ? Ok(response) : BadRequest("null object reference.");
        }
    }
}
