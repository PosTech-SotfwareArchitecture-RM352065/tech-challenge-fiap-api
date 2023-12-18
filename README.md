# tech-challenge-fiap'
Projeto de entrega para POS Tech FIAP de Victor Cangelosi de Lima RM352065

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=PosTech-SotfwareArchitecture-RM352065_tech-challenge-fiap&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=PosTech-SotfwareArchitecture-RM352065_tech-challenge-fiap)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=PosTech-SotfwareArchitecture-RM352065_tech-challenge-fiap&metric=coverage)](https://sonarcloud.io/summary/new_code?id=PosTech-SotfwareArchitecture-RM352065_tech-challenge-fiap)

> [!Note]
> 
> Algumas das configurações que fiz em minha máquina estão concentradas em [Windows Developer Config](https://github.com/cangelosilima/windows-developer-config)

## Pré-quisitos

* [.NET 7](https://dotnet.microsoft.com/pt-br/download/dotnet/7.0)

## Estrutura do projeto

### Documentação
### API Restaurante
### Docker
### Postman

## Desenvolvimento e teste

Para inicializar todo o ambiente exsite a opção via docker compose:
```powershell
cd .\.docker\ | docker-compose up --build
```

Para inicializar cada componente

Base de dados SQL Server:
```powershell
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=P@ssW0rd!" --name database-sanduba -p 1433:1433 -d mcr.microsoft.com/mssql/server:latest 
```
Migration SQL
```powershell
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=P@ssW0rd!" --name database-sanduba -p 1433:1433 -d mcr.microsoft.com/mssql/server:latest 
```


Remover todos os containers:
```powershell
docker stop $(docker ps -a -q) | docker rm $(docker ps -a -q)
```

Para realizar o `build` da solution
```powershell
cd .\api\RestauranteSanduba | dotnet build
```

