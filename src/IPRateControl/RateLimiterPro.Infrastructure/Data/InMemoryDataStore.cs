using RateLimiterPro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace RateLimiterPro.Infrastructure.Data
{
    public class InMemoryDataStore
    {
        public List<RequestModel> Requests { get; } = new List<RequestModel>();
        public Dictionary<string, IPRecord> IPRecords { get; } = new Dictionary<string, IPRecord>();
    }
}
