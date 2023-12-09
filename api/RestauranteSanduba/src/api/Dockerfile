#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 9000

ENV ASPNETCORE_URLS=http://+:9000
ENV ASPNETCORE_ENVIRONMENT Development

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["src/core/Domain/Domain.csproj", "src/core/Domain/"]
COPY ["src/core/Application/Application.csproj", "src/core/Application/"]
COPY ["src/core/Application.Abstraction/Application.Abstraction.csproj", "src/core/Application.Abstraction/"]
COPY ["src/adapter/driven/Infrastructure/Persistence.csproj", "src/adapter/driven/Infrastructure/"]
COPY ["src/api/API.csproj", "src/api/"]
RUN dotnet restore "src/api/API.csproj"
COPY . .
WORKDIR "src/api"
RUN dotnet build "API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RestauranteSanduba.API.dll"]