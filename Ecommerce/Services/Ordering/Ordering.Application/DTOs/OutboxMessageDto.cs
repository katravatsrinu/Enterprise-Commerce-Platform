namespace Ordering.Application.DTOs
{
    public class OutboxMessageDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}