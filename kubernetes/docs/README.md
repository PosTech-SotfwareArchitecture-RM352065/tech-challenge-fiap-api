# Kubernetes

[Retornar ao Inicio](../../README.md)

Inicialização do secret utilizado pelo banco de dados:
```zsh
kubectl create secret generic sanduba-db-secret --from-literal=SA_PASSWORD='P@ssW0rd!'
```

Para inicialização de todos os componentes (volumes, volume claim, pods e services):
```zsh
kubectl apply $(ls ./kubernetes/*-pv.yml | awk ' { print " -f " $1 } ' )
```
```zsh
kubectl apply $(ls ./kubernetes/*-pvc.yml | awk ' { print " -f " $1 } ' )
```
```zsh
kubectl apply $(ls ./kubernetes/*-pod.yml | awk ' { print " -f " $1 } ' )
```
```zsh
kubectl apply $(ls ./kubernetes/*-svc.yml | awk ' { print " -f " $1 } ' )
```

Para remover todos os compromentes (pods, services, etc):
```zsh
kubectl delete $(ls ./kubernetes/*.yml | awk ' { print " -f " $1 } ' )
```


