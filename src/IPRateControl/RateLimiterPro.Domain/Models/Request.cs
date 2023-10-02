namespace RateLimiterPro.Domain.Models
{
    public class Request
    {
        public int Id { get; set; } 
        public string IpAddress { get; set; } 
        public DateTime ReceivedTime { get; set; } 
        public DateTime ProcessedTime { get; set; }
    }
}
