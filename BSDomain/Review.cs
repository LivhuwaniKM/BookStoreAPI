namespace BSDomain
{
    public class Review : BaseEntity
    {
        public int UserId { get; set; }
        public string Message { get; set; } = string.Empty;
        public int Rating { get; set; }
        public DateTime CreatedOn { get; set; } = new DateTime();
    }
}
