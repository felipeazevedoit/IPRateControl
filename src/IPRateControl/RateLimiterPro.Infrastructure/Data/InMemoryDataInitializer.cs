using RateLimiterPro.Domain.Models;

namespace RateLimiterPro.Infrastructure.Data
{
    public class InMemoryDataInitializer
    {
        public static void Initialize(InMemoryDataStore dataStore)
        {
            dataStore.IPRecords["192.168.1.1"] = new IPRecord { IpAddress = "192.168.1.1", RequestCount = 0 };
        }
    }
}
