using RateLimiterPro.Domain.Models;

namespace RateLimiterPro.Application.Interfaces
{
    public interface IQueueManagerService
    {
        Task EnqueueRequestAsync(RequestModel request);
        Task<RequestModel> DequeueRequestAsync();
    }
}
