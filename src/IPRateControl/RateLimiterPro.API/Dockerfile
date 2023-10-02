#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RateLimiterPro.API/RateLimiterPro.API.csproj", "RateLimiterPro.API/"]
RUN dotnet restore "RateLimiterPro.API/RateLimiterPro.API.csproj"
COPY . .
WORKDIR "/src/RateLimiterPro.API"
RUN dotnet build "RateLimiterPro.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RateLimiterPro.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RateLimiterPro.API.dll"]