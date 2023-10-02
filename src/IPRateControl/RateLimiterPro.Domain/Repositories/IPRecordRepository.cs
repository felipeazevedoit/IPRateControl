using RateLimiterPro.Domain.Interfaces;
using RateLimiterPro.Domain.Models;

namespace RateLimiterPro.Domain.Repositories
{
    public class IPRecordRepository : IIPRecordRepository
    {
        private Dictionary<string, IPRecord> ipRecordStore = new Dictionary<string, IPRecord>();

        public IPRecord AddOrUpdate(IPRecord ipRecord)
        {
            if (ipRecordStore.ContainsKey(ipRecord.IpAddress))
            {
                // Atualizar o registro de IP existente
                ipRecordStore[ipRecord.IpAddress].RequestCount = ipRecord.RequestCount;
            }
            else
            {
                // Adicionar um novo registro de IP
                ipRecordStore[ipRecord.IpAddress] = ipRecord;
            }

            return ipRecord;
        }

        public IPRecord GetByIpAddress(string ipAddress)
        {
            if (ipRecordStore.ContainsKey(ipAddress))
            {
                return ipRecordStore[ipAddress];
            }

            return null; // IP não encontrado
        }
    }
}
