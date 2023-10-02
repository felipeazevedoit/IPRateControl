namespace RateLimiterPro.Domain.Models
{
    public class IPRecord
    {
        public string IpAddress { get; set; } 
        public int RequestCount { get; set; }


        public IPRecord() => RequestCount = 0;

        public void IncreaseRequestCount()
        {
            RequestCount++;
        }
    }
}


