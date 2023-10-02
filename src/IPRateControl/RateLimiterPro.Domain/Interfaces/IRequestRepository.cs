using RateLimiterPro.Domain.Models;

namespace RateLimiterPro.Domain.Interfaces
{
    public interface IRequestRepository
    {
        RequestModel Add(RequestModel request);
        RequestModel GetById(int id);
        IEnumerable<RequestModel> GetByIpAddress(string ipAddress);
        void Update(RequestModel request);
    }
}
