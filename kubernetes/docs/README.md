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