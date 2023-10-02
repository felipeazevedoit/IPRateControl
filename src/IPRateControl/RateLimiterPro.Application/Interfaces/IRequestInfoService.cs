using RateLimiterPro.Domain.Models;

namespace RateLimiterPro.Application.Interfaces
{
    public interface IRequestInfoService
    {
        IEnumerable<RequestModel> GetRequestInfo();
    }
}
