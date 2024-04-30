namespace BSDomain
{
    public class Book : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public DateTime Year { get; set; } = new DateTime();
    }

    /*public class BookExt : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Isbn { get; set; } = string.Empty;
        public string Edition { get; set; } = string.Empty;
        public DateTime PublicationYear { get; set; } = new DateTime();
    }

    public class AuthorExt : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string BookId { get; set; } = string.Empty;
    }

    public class GenreExt : BaseEntity
    {
        public string GenreName { get; set; } = string.Empty;
    }*/
}