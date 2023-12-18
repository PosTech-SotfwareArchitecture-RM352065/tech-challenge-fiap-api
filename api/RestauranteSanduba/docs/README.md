# API Restaurante Sanduba
Esta API foi construida como parte das entregas da p�s-gradu��o de Software Architecture da FIAP PosTech. O objetivo foi explorar, para o contexto de um restaurante com autoatendimento, novas t�ncologias e paradigmas como:
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

## M�dulos do sistema
A aplica��o est� consolidada dentro da pasta `\src` e est� desenhada pelo padr�o de `Clean Architecture` com "toques" de `Domain Driven Design` e `Ports and Adapters`. Assim:
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
Camada com as entidades do dom�nio Esta camada est� 

#### Core Application
Camada com todos os casos de uso. 

### Testes
Testes est�o consolidados dentro da pasta `\tests`. Sendo utilizado estrat�gias espec�ficas para cada tipo de camada e teste.

#### Testes Unit�rios (Unit Test)

- Dom�nio

#### Testes de Comportamento (Behavior Tests)

- Aplication (.Abstraction)

#### Testes de Integra��o (Integration Tests)

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

