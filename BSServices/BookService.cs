using BSDomain;
using BSRepositories;

namespace BSServices
{
    public class BookService(IBookRepository bookRepository) : IBookService
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public string CreateBook(Book book)
        {
            return _bookRepository.AddBook(book);
        }

        public bool DeleteBook(int id)
        {
            return _bookRepository.DeleteBook(id);
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public Book GetBookByIsbn(string isbn)
        {
            return _bookRepository.GetBookByIsbn(isbn);
        }

        public string UpdateBook(Book book)
        {
            return _bookRepository.UpdateBook(book);
        }
    }
}
