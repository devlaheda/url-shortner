param location  string = resourceGroup().location
var uniqueId = uniqueString(resourceGroup().id) 

module vault 'secrets/keyvault.bicep' = {
  name: 'keyVaultDeployment'
  params:{
    name : 'kv-${uniqueId}'
    location: location    
  }
}
module apiService 'modules/appservices.bicep' ={
  name: 'apiDeployment'
  params:{
    appName:'api-${uniqueId}'
    appServicePlanName:'plan-api-${uniqueId}'
    location:location
    keyVaultName:vault.outputs.name
  }
  //dependsOn:[vault]
}
module keyVaultRoleAssignment 'secrets/keyVaultRoleAssignment.bicep' = {  
  name: 'keyVaultRoleAssignmentDeployment'
  params:{
    keyVaultName: vault.outputs.name
    principalIds:[
      apiService.outputs. appServicePrincipalId
    ]
  }
  //dependsOn:[vault , apiService]
}
module cosmosDb 'modules/cosmosDb.bicep' = {
  name: 'cosmosDbDeployment'
  params:{
    name: 'consmos-db-${uniqueId}'
    location: location
    kind: 'GlobalDocumentDB'
    databaseName:'urls'
    locationName: 'France Central'
    keyVaultName: vault.outputs.name
  }
}
