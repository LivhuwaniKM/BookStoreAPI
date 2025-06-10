namespace BSDomain
{
    public class Book : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string Edition { get; set; } = string.Empty;
        public DateTime? Year { get; set; }
    }
}