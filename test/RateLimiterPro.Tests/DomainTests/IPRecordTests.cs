using RateLimiterPro.Domain.Models;
using Xunit;

namespace RateLimiterPro.Tests.DomainTests
{
    public class IPRecordTests
    {
        [Fact]
        public void IPRecord_Should_Be_Created_With_Default_Values()
        {
            // Arrange & Act
            var ipRecord = new IPRecord();

            // Assert
            Assert.NotNull(ipRecord);
            Assert.Equal(0, ipRecord.RequestCount);
            // Adicione mais verificações para outros campos, se necessário
        }

        [Fact]
        public void IPRecord_Should_Increase_RequestCount_Correctly()
        {
            // Arrange
            var ipRecord = new IPRecord();

            // Act
            ipRecord.IncreaseRequestCount();
            ipRecord.IncreaseRequestCount();
            ipRecord.IncreaseRequestCount();

            // Assert
            Assert.Equal(3, ipRecord.RequestCount);
        }
    }

}
