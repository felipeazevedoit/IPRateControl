namespace RateLimiterPro.Domain.Models
{
    public class IPRecord
    {
        public string IpAddress { get; set; } 
        public int RequestCount { get; set; } 
    }
}


