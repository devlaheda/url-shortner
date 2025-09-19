param keyVaultName string
param principalIds array
param principalType string  = 'ServicePrincipal'
param roleDefinitionId string  = '4633458b-17de-408a-b874-0445c86b69e6' // This may be different in your case check your azure portal 
resource keyVault 'Microsoft.KeyVault/vaults@2024-11-01' existing = {
  name:keyVaultName
 }
resource keyVaultRleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = [
  for id in principalIds : {
    name: guid(keyVault.id,id,roleDefinitionId)
    scope:keyVault
    properties:{
      roleDefinitionId:subscriptionResourceId('Microsoft.Authorization/roleAssignments',roleDefinitionId)
      principalId:id
      principalType: principalType
    }  
  }
]
