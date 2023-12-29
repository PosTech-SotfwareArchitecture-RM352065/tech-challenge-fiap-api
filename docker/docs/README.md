# Docker
[Retornar ao Inicio](../../README.md)

[Docker](https://www.docker.com/) é uma plataforma de código aberto projetada para facilitar a criação, implantação e execução de aplicativos em contêineres. Os contêineres são ambientes leves e portáteis que empacotam tudo o que é necessário para executar um software, incluindo o código, as bibliotecas e as dependências.

Para inicialização dos componentes é possível utilizar o docker. Tanto para inicialização componente a componente, como via docker compose

## Docker compose
A inicialização dos componentes pode ser facilitada pelo uso do Docker, seja de maneira incremental, iniciando cada componente individualmente, ou de forma mais abrangente, através do docker compose.

Remover todos os containers:
```zsh
docker stop $(docker ps -a -q) | docker rm $(docker ps -a -q)
```

Inicialização do docker a partir da raiz:
```zsh
docker-compose --file ./docker/docker-compose.yml up --build --detach
```

## Docker run

NFS Server
```zsh
docker run -d --name nfs-sanduba --privileged -v /data/nfs-storage:/data -e SHARED_DIRECTORY=/data -p 2049:2049 -d itsthenetwork/nfs-server-alpine:12 
```

SQL Server
```zsh
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=P@ssW0rd!" --name database-sanduba -p 1433:1433 -d mcr.microsoft.com/mssql/server:latest 
```

API
As imagens geradas da api são enviadas para o [cangelosilima | Docker Hub](https://hub.docker.com/repositories/cangelosilima). O [Dockerfile](../../api/RestauranteSanduba/src/api/Dockerfile) realiza a configuração que 