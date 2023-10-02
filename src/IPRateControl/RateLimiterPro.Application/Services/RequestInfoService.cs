using RateLimiterPro.Application.Interfaces;
using RateLimiterPro.Domain.Models;

namespace RateLimiterPro.Application.Services
{
    public class RequestInfoService : IRequestInfoService
    {
        private readonly List<RequestModel> mockRequests = new List<Request>
        {
            new RequestModel { Id = 1, ReceivedTime = "12:00:10", ProcessedTime = "12:00:15" },
            new RequestModel { Id = 2, ReceivedTime = "12:01:20", ProcessedTime = "12:01:25" },
            new RequestModel { Id = 3, ReceivedTime = "12:02:30", ProcessedTime = "12:02:35" }
        };

        public IEnumerable<RequestModel> GetRequestInfo()
        {
            return mockRequests;
        }

    }
}
