#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/adapter/driver/API/API.csproj", "src/adapter/driver/API/"]
COPY ["src/core/Application/Application.csproj", "src/core/Application/"]
COPY ["src/core/Domain/Domain.csproj", "src/core/Domain/"]
COPY ["src/adapter/driven/Infrastructure/Infrastructure.csproj", "src/adapter/driven/Infrastructure/"]
RUN dotnet restore "src/adapter/driver/API/API.csproj"
COPY . .
WORKDIR "/src/src/adapter/driver/API"
RUN dotnet build "API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RestauranteSanduba.Adapter.Driven.API.dll"]