using RateLimiterPro.Application.Interfaces;
using RateLimiterPro.Application.Services;
using RateLimiterPro.Domain.Repositories;
using RateLimiterPro.Domain.Interfaces;
using RateLimiterPro.Infrastructure.Queue;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRequestRateLimiterService, RequestRateLimiterService>();
builder.Services.AddScoped<IQueueManagerService, QueueManagerService>();
builder.Services.AddScoped<IRequestInfoService, RequestInfoService>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IIPRecordRepository, IPRecordRepository>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AsyncRequestQueue>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();