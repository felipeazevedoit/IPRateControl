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
        private List<Request> requestStore = new List<Request>();
        private int nextId = 1;

        public Request Add(Request request)
        {
            request.Id = nextId++;
            requestStore.Add(request);
            return request;
        }

        public Request GetById(int id)
        {
            return requestStore.Find(request => request.Id == id);
        }

        public IEnumerable<Request> GetByIpAddress(string ipAddress)
        {
            return requestStore.FindAll(request => request.IpAddress == ipAddress);
        }

        public void Update(Request request)
        {
            // Implementar lógica para atualização, se necessário
        }
    }
}
