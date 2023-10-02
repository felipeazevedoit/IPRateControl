using RateLimiterPro.Domain.Models;

namespace RateLimiterPro.Domain.Interfaces
{
    public interface IIPRecordRepository
    {
        IPRecord AddOrUpdate(IPRecord ipRecord);
        IPRecord GetByIpAddress(string ipAddress);
    }
}
