using RateLimiterPro.Domain.Models;

namespace RateLimiterPro.Domain.Interfaces
{
    public interface IRequestRepository
    {
        Request Add(Request request);
        Request GetById(int id);
        IEnumerable<Request> GetByIpAddress(string ipAddress);
        void Update(Request request);
    }
}
