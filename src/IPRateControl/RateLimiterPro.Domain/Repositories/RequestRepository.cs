using RateLimiterPro.Domain.Interfaces;
using RateLimiterPro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateLimiterPro.Domain.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private List<RequestModel> requestStore = new List<RequestModel>();
        private int nextId = 1;

        public RequestModel Add(RequestModel request)
        {
            request.Id = nextId++;
            requestStore.Add(request);
            return request;
        }

        public RequestModel GetById(int id)
        {
            return requestStore.Find(request => request.Id == id);
        }

        public IEnumerable<RequestModel> GetByIpAddress(string ipAddress)
        {
            return requestStore.FindAll(request => request.IpAddress == ipAddress);
        }

        public void Update(RequestModel request)
        {
            // Implementar lógica para atualização, se necessário
        }
    }
}
