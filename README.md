## login to Azure in CLI
```bash
az login
```
## Create aresource groupe 
 ```bash
 az group create --name yourgroupName --location location
```
## Deployment with CLI
```bash
az deployment  group create --resource-group yourgroupeName --template-file infrastructure/main.bicep
```
## Create Github Role 
```bash
az ad sp create-for-rbac -n Github-Actions-SP  --role contributor --scopes /subscriptions/{yourID}  --sdk-auth