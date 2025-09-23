param location string
param name string
 resource keyVault 'Microsoft.KeyVault/vaults@2024-11-01' = {
  name: name
  location: location
  properties: {
    sku: {
      family:'A'
      name:'standard'    
    }
    enableRbacAuthorization:true
    tenantId: subscription().tenantId
  }
 }
 output id string = keyVault.id
 output name string = keyVault.name
