namespace BSDomain
{
    public class Notification : BaseEntity
    {
        public string Type { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
