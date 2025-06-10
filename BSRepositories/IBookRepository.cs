using BSDomain;

namespace BSRepositories
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBookByIsbn(string isbn);
        string AddBook(Book book);
        string UpdateBook(Book book);
        bool DeleteBook(int id);
    }
}
