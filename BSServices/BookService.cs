using BSDomain;
using BSRepositories;

namespace BSServices
{
    public class BookService(IBookRepository bookRepository) : IBookService
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public string AddBook(Book book)
        {
            return _bookRepository.AddBook(book);
        }

        public string DeleteBook(Book book)
        {
            return _bookRepository.DeleteBook(book);
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public Book GetBookByIsbn(string isbn)
        {
            return _bookRepository.GetBookByIsbn(isbn);
        }

        public Book GetBookByIsbn(Book book)
        {
            return _bookRepository.GetBookByIsbn(book);
        }

        public string UpdateBook(Book book)
        {
            return _bookRepository.UpdateBook(book);
        }
    }
}
