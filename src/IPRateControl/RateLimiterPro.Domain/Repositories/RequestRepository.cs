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
        private readonly List<RequestModel> requestStore = new List<RequestModel>();
    
        public int NextId { get; set; }

        public RequestRepository()
        {
            NextId = 1;

            //MOCK
            var request1 = new RequestModel
            {
                Id = 1,
                ReceivedTime = DateTime.Parse("2023-01-15 12:00:10"),
                ProcessedTime = DateTime.Parse("2023-01-15 12:00:15")
            };

            var request2 = new RequestModel { Id = 2, ReceivedTime = DateTime.Parse("2023-01-15 12:01:20"), ProcessedTime = DateTime.Parse("2023-01-15 12:01:25") };

            var request3 = new RequestModel
            {
                Id = 3,
                ReceivedTime = DateTime.Parse("2023-01-15 12:02:30"),
                ProcessedTime = DateTime.Parse("2023-01-15 12:02:35")
            };


            requestStore.Add(request1);
            requestStore.Add(request2);
            requestStore.Add(request3);
        }

       
        public RequestModel Add(RequestModel request)
        {
            request.Id = NextId++;
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

        public void AddRequest(RequestModel request)
        {
            throw new NotImplementedException();
        }

        public object GetRequestById(int requestId)
        {
            throw new NotImplementedException();
        }
    }
}
