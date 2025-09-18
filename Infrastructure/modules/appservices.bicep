

param location  string 
param appServicePlanName string
param appName string 
resource appServicePlan 'Microsoft.Web/serverfarms@2024-11-01' ={
  location: location
  kind:'linux'
  name : appServicePlanName
  properties:{
    reserved:true
  }
  sku:{
    name:'B1'
  }
}
resource webApp 'Microsoft.Web/sites@2024-11-01'= {
  location:location
  name: appName

  properties:{
    serverFarmId:appServicePlan.id
    httpsOnly:true
    siteConfig:{
      linuxFxVersion:'DOTNETCORE|8.0'
    }
  }
}
resource webAppConfig 'Microsoft.Web/sites/config@2024-11-01' = {
  name: 'web'
  parent: webApp
  properties:{
    scmType:'GitHub'
  }
}

output appServiceId string =  webApp.id
