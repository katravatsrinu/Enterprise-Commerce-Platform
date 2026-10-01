namespace Ordering.Core.Entities
{
    public class OutboxMessage
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ProcessedAt { get; set; }
        public string Error { get; set; }
    }
}