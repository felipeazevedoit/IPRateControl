using RateLimiterPro.Application.Interfaces;
using RateLimiterPro.Domain.Interfaces;
using RateLimiterPro.Domain.Models;

namespace RateLimiterPro.Application.Services
{
    public class RequestRateLimiterService : IRequestRateLimiterService
    {
        private readonly IIPRecordRepository ipRecordRepository;

        public RequestRateLimiterService(IIPRecordRepository ipRecordRepository)
        {
            this.ipRecordRepository = ipRecordRepository;
        }

        public bool IsRequestAllowed(string ipAddress)
        {
            try
            {
                IPRecord ipRecord = ipRecordRepository.GetByIpAddress(ipAddress);

                if (IsRequestLimitExceeded(ipRecord)) return false;

                UpdateIpRecord(ipAddress, ipRecord);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        private static bool IsRequestLimitExceeded(IPRecord ipRecord)
        {
            return ipRecord != null && ipRecord.RequestCount >= 3;
        }

        private void UpdateIpRecord(string ipAddress, IPRecord ipRecord)
        {
            if (ipRecord is null)
                ipRecord = new IPRecord { IpAddress = ipAddress, RequestCount = 1 };
            else
                ipRecord.RequestCount++;

            ipRecordRepository.AddOrUpdate(ipRecord);
        }

    }
}
