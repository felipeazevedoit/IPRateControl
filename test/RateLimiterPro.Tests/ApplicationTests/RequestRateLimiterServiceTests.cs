using RateLimiterPro.Application.Services;
using RateLimiterPro.Domain.Interfaces;
using RateLimiterPro.Domain.Models;
using Xunit;

namespace RateLimiterPro.Tests.ApplicationTests
{
    public class RequestRateLimiterServiceTests
    {
        [Fact]
        public void IsRequestAllowed_Should_Return_True_For_Valid_IP()
        {
            // Arrange
            var ipRecordRepository = new MockIPRecordRepository();
            var requestRateLimiterService = new RequestRateLimiterService(ipRecordRepository);

            // Act
            bool isAllowed = requestRateLimiterService.IsRequestAllowed("192.168.1.1");

            // Assert
            Assert.True(isAllowed);
        }

        [Fact]
        public void IsRequestAllowed_Should_Return_False_For_Exceeded_Limit_IP()
        {
            // Arrange
            var ipRecordRepository = new MockIPRecordRepository();
            var requestRateLimiterService = new RequestRateLimiterService(ipRecordRepository);

            // Simulate exceeding the limit
            ipRecordRepository.AddOrUpdate(new IPRecord { IpAddress = "192.168.1.1", RequestCount = 3 });

            // Act
            bool isAllowed = requestRateLimiterService.IsRequestAllowed("192.168.1.1");

            // Assert
            Assert.False(isAllowed);
        }
    }

    public class MockIPRecordRepository : IIPRecordRepository
    {
        private IPRecord? ipRecord;

        public IPRecord GetByIpAddress(string ipAddress)
        {
            return ipRecord;
        }

        public void AddOrUpdate(IPRecord record)
        {
            ipRecord = record;
        }

        IPRecord IIPRecordRepository.AddOrUpdate(IPRecord ipRecord)
        {
            throw new NotImplementedException();
        }
    }
}
