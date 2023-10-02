using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateLimiterPro.Application.Interfaces;
using RateLimiterPro.Domain.Models;

namespace RateLimiterPro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateLimiterController : ControllerBase
    {
        private readonly IRequestRateLimiterService rateLimiterService;
        private readonly IQueueManagerService queueManagerService;

        public RateLimiterController(IRequestRateLimiterService rateLimiterService, IQueueManagerService queueManagerService)
        {
            this.rateLimiterService = rateLimiterService;
            this.queueManagerService = queueManagerService;
        }

        [HttpGet("isRequestAllowed")]
        public IActionResult IsRequestAllowed(string ipAddress)
        {
            if (string.IsNullOrWhiteSpace(ipAddress))
                return BadRequest("Invalid IP Address");

            bool isAllowed = rateLimiterService.IsRequestAllowed(ipAddress);

            if (isAllowed) return Ok("Request is allowed.");
        
            else return StatusCode(429, "Rate limit exceeded. Please try again later.");

        }

        [HttpPost("enqueueRequest")]
        public IActionResult EnqueueRequest([FromBody] RequestModel request)
        {
            if (request is null) return BadRequest("Invalid request data");
            

            try
            {
                queueManagerService.EnqueueRequestAsync(request);
                return Ok("Request enqueued successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error enqueuing request: {ex.Message}");
            }
        }

        [HttpGet("dequeueRequest")]
        public IActionResult DequeueRequest()
        {
            try
            {
                var dequeuedRequest = queueManagerService.DequeueRequestAsync().Result; // Bloqueante neste exemplo, você pode considerar async/await aqui.

                if (dequeuedRequest != null)
                {
                    return Ok(dequeuedRequest);
                }
                else
                {
                    return NotFound("No requests in the queue.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error dequeuing request: {ex.Message}");
            }
        }
    }
}
