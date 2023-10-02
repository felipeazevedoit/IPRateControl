using RateLimiterPro.Domain.Models;
using Xunit;

namespace RateLimiterPro.Tests.DomainTests
{
    public class RequestTests
    {
        [Fact]
        public void Request_Should_Be_Created_With_Default_Values()
        {
            var request = new RequestModel();

            Assert.NotNull(request);
        }

    }
}
