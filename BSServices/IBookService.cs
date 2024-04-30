using BSDomain;

namespace BSServices
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetBookByIsbn(string isbn);
        Book GetBookByIsbn(Book book);
        string AddBook(Book book);
        string UpdateBook(Book book);
        string DeleteBook(Book book);
    }
}
