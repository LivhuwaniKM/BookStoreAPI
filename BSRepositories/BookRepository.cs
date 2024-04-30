using BSCore;
using BSDomain;

namespace BSRepositories
{
    public class BookRepository(BookStoreDbContext dbContext) : IBookRepository
    {
        private readonly BookStoreDbContext _dbContext = dbContext;

        public List<Book> GetAllBooks()
        {
            return [.. _dbContext.Books];
        }

        public Book GetBookByIsbn(string isbn)
        {
            return _dbContext.Books.First(c => c.ISBN == isbn);
        }

        public Book GetBookByIsbn(Book book)
        {
            return _dbContext.Books.First(c => c.ISBN == book.ISBN);
        }

        public string AddBook(Book book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            return "success";
        }

        public string UpdateBook(Book book)
        {
            var existingBook = _dbContext.Books.First(c => c.ISBN == book.ISBN);

            var rowsAffected = 0;

            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.ISBN = book.ISBN;
                existingBook.Year = book.Year;

                rowsAffected = _dbContext.SaveChanges();
            }

            if (rowsAffected > 0)
                return "success";
            else
                return "error";
        }

        public string DeleteBook(Book book)
        {
            var recordToDelete = _dbContext.Books.Single(c => c.ISBN == book.ISBN);

            _dbContext.Books.Remove(recordToDelete);
            var rowsAffected = _dbContext.SaveChanges();

            if (rowsAffected > 0)
                return "success";
            else
                return "error";
        }

    }
}
