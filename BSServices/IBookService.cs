using BSDomain;

namespace BSServices
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetBookByIsbn(string isbn);
        string CreateBook(Book book);
        string UpdateBook(Book book);
        bool DeleteBook(int id);
    }
}
