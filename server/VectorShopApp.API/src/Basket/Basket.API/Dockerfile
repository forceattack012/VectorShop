#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Basket/Basket.API/Basket.API.csproj", "Basket/Basket.API/"]
COPY ["Basket/Basket.Application/Basket.Application.csproj", "Basket/Basket.Application/"]
COPY ["EventBusRabbitMQ/EventBusRabbitMQ.csproj", "EventBusRabbitMQ/"]
COPY ["Basket/Basket.Domain/Basket.Domain.csproj", "Basket/Basket.Domain/"]
COPY ["Basket/Basket.Infrastructure/Basket.Infrastructure.csproj", "Basket/Basket.Infrastructure/"]
RUN dotnet restore "src/Basket/Basket.API/Basket.API.csproj"
COPY . .
WORKDIR "/src/src/Basket/Basket.API"
RUN dotnet build "Basket.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Basket.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Basket.API.dll"]