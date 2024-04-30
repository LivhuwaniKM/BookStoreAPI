using BSDomain;
using Microsoft.EntityFrameworkCore;

namespace BSCore
{
    public class BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : DbContext(options)
    {
        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Clean Code",
                    Author = "Robert C. Martin",
                    ISBN = "8797-ADGH-IWNJ",
                    Year = new DateTime(2022, 1, 1)
                },
                new Book
                {
                    Id = 2,
                    Title = "Design Patterns: Elements of Reusable Object-Oriented Software",
                    Author = "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides",
                    ISBN = "978-0201633610",
                    Year = new DateTime(1994, 10, 31)
                },
                new Book
                {
                    Id = 3,
                    Title = "The Pragmatic Programmer",
                    Author = "Andrew Hunt, David Thomas",
                    ISBN = "978-0201616224",
                    Year = new DateTime(1999, 10, 30)
                },
                new Book
                {
                    Id = 4,
                    Title = "Python Programming",
                    Author = "Guido van Rossum",
                    ISBN = "672-2638643868",
                    Year = new DateTime(2001, 3, 12)
                },
                new Book
                {
                    Id = 5,
                    Title = "Pragmatic Concepts",
                    Author = "Unknown",
                    ISBN = "433-2638643888",
                    Year = new DateTime(1800, 1, 1)
                },
                new Book
                {
                    Id = 6,
                    Title = "Advanced Python Programming",
                    Author = "O'Reilly",
                    ISBN = "122-3366553888",
                    Year = new DateTime(1600, 1, 1)
                });

            modelBuilder.Entity<Notification>().HasData(
                new Notification
                {
                    Id = 1,
                    Type = "success",
                    Message = "Request has been processed successfully"
                },
                new Notification
                {
                    Id = 2,
                    Type = "error",
                    Message = "An error has occured while processing request"
                });
        }
    }
}
