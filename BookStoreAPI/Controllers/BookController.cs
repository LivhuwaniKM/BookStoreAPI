using BSDomain;
using BSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace BookStore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [DisplayName("WHAT")]
    public class BookController(IBookService bookService) : ControllerBase
    {
        private readonly IBookService _bookService = bookService;

        [HttpGet("ienumerable")]
        public IEnumerable<Book> GetAllBooks()
        {
            var response = _bookService.GetAllBooks();
            return response;
        }

        [HttpGet("actionresult")]
        public ActionResult<List<Book>> Get()
        {
            return _bookService.GetAllBooks();
        }

        [HttpGet("{isbn}")]
        public ActionResult<Book> GetBookByIsbn(string isbn)
        {
            var response = _bookService.GetBookByIsbn(isbn);
            return Ok(response);
        }

        [HttpGet("query")]
        public ActionResult GetBookByIsbn([FromQuery] Book book)
        {
            var response = _bookService.GetBookByIsbn(book);
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Book> AddBook([FromBody] Book book)
        {
            var response = _bookService.AddBook(book);
            if (response != null)
                return Ok(response);
            else
                return BadRequest();
        }

        [HttpPut("{isbn}")]
        public ActionResult<Book> UpdateBook(string isbn, [FromBody] Book updatedBook)
        {
            var response = _bookService.UpdateBook(updatedBook);
            return Ok(response);
        }

        [HttpDelete]
        public ActionResult DeleteBook(Book book)
        {
            var response = _bookService.DeleteBook(book);
            return Ok(response);
        }
    }
}
