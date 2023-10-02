using RateLimiterPro.Application.Interfaces;
using RateLimiterPro.Domain.Models;
using RateLimiterPro.Infrastructure.Queue;

namespace RateLimiterPro.Application.Services
{
    public class QueueManagerService : IQueueManagerService
    {
        private readonly AsyncRequestQueue requestQueue;

        public QueueManagerService(AsyncRequestQueue requestQueue)
        {
            this.requestQueue = requestQueue ?? throw new ArgumentNullException(nameof(requestQueue));
        }

        public async Task EnqueueRequestAsync(RequestModel request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));
   
            try
            {
                await requestQueue.EnqueueRequestAsync(request);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }
        public async Task<RequestModel> DequeueRequestAsync()
        {
            try
            {
                return requestQueue.DequeueRequest();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
