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

        public bool DeleteBook(int id)
        {
            var recordToDelete = _dbContext.Books.Single(c => c.Id == id);

            _dbContext.Books.Remove(recordToDelete);
            var rowsAffected = _dbContext.SaveChanges();

            if (rowsAffected > 0)
                return true;
            else
                return false;
        }

    }
}
