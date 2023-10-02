using RateLimiterPro.Domain.Models;
using RateLimiterPro.Domain.Repositories;
using Xunit;

namespace RateLimiterPro.Tests.InfrastructureTests
{
    public class RequestRepositoryTests
    {
        [Fact]
        public void AddRequest_Should_Add_Request_To_Database()
        {
            //// Arrange
            //var dbContext = new MockDbContext(); // Use um contexto de banco de dados fictício para testes
            //var requestRepository = new RequestRepository(dbContext);
            //var request = new RequestModel { /* Preencha os dados da solicitação */ };

            //// Act
            //requestRepository.AddRequest(request);

            //// Assert
            //Assert.Contains(request, dbContext.Requests);
        }

        [Fact]
        public void GetRequestById_Should_Retrieve_Request_From_Database()
        {
            //// Arrange
            //var dbContext = new MockDbContext(); 
            //var requestRepository = new RequestRepository(dbContext);
            //var requestId = 1; 

            //// Act
            //var request = requestRepository.GetRequestById(requestId);

            //// Assert
            //Assert.NotNull(request);
            //Assert.Equal(requestId, request.Id);
        }
    }

    public class MockDbContext
    {
        public List<RequestModel> Requests { get; set; } = new List<RequestModel>();
    }
}
