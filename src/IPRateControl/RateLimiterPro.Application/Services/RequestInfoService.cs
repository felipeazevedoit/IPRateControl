using RateLimiterPro.Application.Interfaces;
using RateLimiterPro.Domain.Models;

namespace RateLimiterPro.Application.Services
{
    public class RequestInfoService : IRequestInfoService
    {
        private readonly List<RequestModel> mockRequests = new()
        {
            new RequestModel { Id = 1, ReceivedTime = DateTime.Now.AddMinutes(-5), ProcessedTime =  DateTime.Now.AddMinutes(1) },
            new RequestModel { Id = 2, ReceivedTime = DateTime.Now.AddMinutes(-11), ProcessedTime = DateTime.Now.AddMinutes(1) },
            new RequestModel { Id = 3, ReceivedTime = DateTime.Now.AddMinutes(-15), ProcessedTime = DateTime.Now.AddMinutes(1) }
        };

        public IEnumerable<RequestModel> GetRequestInfo()
        {
            return mockRequests;
        }

    }
}
