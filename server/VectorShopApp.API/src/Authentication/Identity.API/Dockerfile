#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Authentication/Identity.API/Identity.API.csproj", "src/Authentication/Identity.API/"]
COPY ["src/Authentication/Identity.Application/Identity.Application.csproj", "src/Authentication/Identity.Application/"]
COPY ["src/Authentication/Identity.Domain/Identity.Domain.csproj", "src/Authentication/Identity.Domain/"]
COPY ["src/Basket/Basket.Domain/Basket.Domain.csproj", "src/Basket/Basket.Domain/"]
COPY ["src/Authentication/Identity.Infrastucture/Identity.Infrastucture.csproj", "src/Authentication/Identity.Infrastucture/"]
RUN dotnet restore "src/Authentication/Identity.API/Identity.API.csproj"
COPY . .
WORKDIR "/src/src/Authentication/Identity.API"
RUN dotnet build "Identity.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Identity.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity.API.dll"]
