# API Restaurante Sanduba
[Retornar ao Inicio](../../../README.md)

Esta API foi construida como parte das entregas da pós-gradução de Software Architecture da FIAP PosTech. O objetivo foi explorar, para o contexto de um restaurante com autoatendimento, novas téncologias e paradigmas como:
- DDD
- Event Sourcing
- Microservices
- TDD

## Tecnologias utilizadas
- [.NET 7](https://dotnet.microsoft.com/pt-br/download/dotnet/7.0)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [ASP.NET Core](https://learn.microsoft.com/pt-br/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-7.0)
- [Swashbuckcle](https://aka.ms/aspnetcore/swashbuckle)
- [SpecFlow](https://specflow.org/)
- [AspNetCore.Diagnostics.HealthChecks](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks)

## Módulos do sistema
A aplicação está consolidada dentro da pasta `\src` e está desenhada pelo padrão de `Clean Architecture` com "toques" de `Domain Driven Design` e `Ports and Adapters`. Assim:
- Core
	- Domain
	- Application
	- Application.Abstraction
- Adapter
	- driven
		- Infrastructure
	- driver
		- API
		- Controller
		- 
### API

#### Core Domain
Camada com as entidades do domínio.

#### Core Application
Camada com todos os casos de uso. 

### Testes
Testes estão consolidados dentro da pasta `\tests`. Sendo utilizado estratégias específicas para cada tipo de camada e teste.

#### Testes Unitários (Unit Test)

- Domínio

#### Testes de Comportamento (Behavior Tests)

- Aplication (.Abstraction)

#### Testes de Integração (Integration Tests)

*Adapters*
- Persistence
- Messaging
- Controllers
 
#### Testes End-to-End (E2E Tests)

*Driver Adapter*
- API

## Comandos

### API
```powershell
docker build ./api/RestauranteSanduba/src -f ./api/RestauranteSanduba/src/api/Dockerfile --force-rm --tag 'restaurantesanduba.api'  --progress=plain --no-cache | docker run restaurantesanduba.api
```

