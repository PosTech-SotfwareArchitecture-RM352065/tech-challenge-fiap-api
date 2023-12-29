# Kubernetes

[Retornar ao Inicio](../../README.md)

Para inicialização de todos os pods:
```zsh
kubectl apply $(ls ./kubernetes/*-pod.yml | awk ' { print " -f " $1 } ' )
```

Para inicialização de todos os services:
```zsh
kubectl apply $(ls ./kubernetes/*-svc.yml | awk ' { print " -f " $1 } ' )
```

Para remover todos os compromentes (pods, services, etc):
```zsh
kubectl delete $(ls ./kubernetes/*.yml | awk ' { print " -f " $1 } ' )
```

Inicialização do SQL Server:
```zsh
kubectl create secret generic sanduba-db-secret --from-literal=SA_PASSWORD='P@ssW0rd!'
```
