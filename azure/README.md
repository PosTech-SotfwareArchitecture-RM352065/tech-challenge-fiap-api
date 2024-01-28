az group create --name  fiap-tech-challenge --location eastus

az aks create --resource-group fiap-tech-challenge --name fiap-tech-challenge-cluster --node-count 1 --enable-addons monitoring --generate-ssh-keys --node-vm-size Standard_B2s

az aks get-credentials --resource-group fiap-tech-challenge --name fiap-tech-challenge-cluster