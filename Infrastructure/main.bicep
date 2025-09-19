param location  string = resourceGroup().location
var uniqueId = uniqueString(resourceGroup().id) 
module apiService 'modules/appservices.bicep' ={
  name: 'apiDeployment'
  params:{
    appName:'api-${uniqueId}'
    appServicePlanName:'plan-api-${uniqueId}'
    location:location
  }
}

module vault 'secrets/keyvault.bicep' = {
  name: 'keyVaultDeployment'
  params:{
    name : 'kv-${uniqueId}'
    location: location    
  }
}
