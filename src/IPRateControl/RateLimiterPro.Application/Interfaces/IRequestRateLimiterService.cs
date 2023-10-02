namespace RateLimiterPro.Application.Interfaces
{
    public interface IRequestRateLimiterService
    {
        bool IsRequestAllowed(string ipAddress);
    }
}
