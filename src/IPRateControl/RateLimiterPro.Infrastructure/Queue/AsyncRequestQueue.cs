﻿using RateLimiterPro.Domain.Models;
using System.Collections.Concurrent;

namespace RateLimiterPro.Infrastructure.Queue
{
    public class AsyncRequestQueue
    {
        private readonly ConcurrentQueue<RequestModel> requestQueue = new();
        private readonly SemaphoreSlim semaphore = new(3);
        public async Task EnqueueRequestAsync(RequestModel request)
        {
            requestQueue.Enqueue(request);
            await semaphore.WaitAsync();

            async Task<RequestModel> DequeueRequestAsync()
            {
                if (requestQueue.TryDequeue(out var request))
                {
                    return request;
                }

                return null;
            }

            void ReleaseSlot()
            {
                semaphore.Release();
            }
        }
        public RequestModel? DequeueRequest()
        {
            if (requestQueue.TryDequeue(out var request))
                return request;

            return null;
        }
    }
}