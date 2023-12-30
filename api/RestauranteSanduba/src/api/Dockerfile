#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 9000

ENV ASPNETCORE_URLS=http://+:9000
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_ConnectionStrings__DefaultConnection= 

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /staging

COPY ["core/Domain/Domain.csproj", "core/Domain/"]
COPY ["core/Application/Application.csproj", "core/Application/"]
COPY ["core/Application.Abstraction/Application.Abstraction.csproj", "core/Application.Abstraction/"]
COPY ["adapter/driven/Infrastructure/Persistence.csproj", "adapter/driven/Infrastructure/"]
COPY ["api/API.csproj", "api/"]

RUN dotnet restore "api/API.csproj"

COPY . .

WORKDIR "/staging/api"
RUN dotnet build "API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RestauranteSanduba.API.dll"]