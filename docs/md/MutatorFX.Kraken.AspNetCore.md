<a name='assembly'></a>
# MutatorFX.Kraken.AspNetCore

## Contents

- [WebHostingExtensions](#T-MutatorFX-Kraken-AspNetCore-WebHostingExtensions 'MutatorFX.Kraken.AspNetCore.WebHostingExtensions')
  - [UseKrakenModule\`\`1(webHostBuilder)](#M-MutatorFX-Kraken-AspNetCore-WebHostingExtensions-UseKrakenModule``1-Microsoft-AspNetCore-Hosting-IWebHostBuilder- 'MutatorFX.Kraken.AspNetCore.WebHostingExtensions.UseKrakenModule``1(Microsoft.AspNetCore.Hosting.IWebHostBuilder)')
  - [UseKrakenModule\`\`1(webHostBuilder,krakenModule)](#M-MutatorFX-Kraken-AspNetCore-WebHostingExtensions-UseKrakenModule``1-Microsoft-AspNetCore-Hosting-IWebHostBuilder,``0- 'MutatorFX.Kraken.AspNetCore.WebHostingExtensions.UseKrakenModule``1(Microsoft.AspNetCore.Hosting.IWebHostBuilder,``0)')
  - [UseKrakenStartupTask\`\`1(webHost)](#M-MutatorFX-Kraken-AspNetCore-WebHostingExtensions-UseKrakenStartupTask``1-Microsoft-AspNetCore-Hosting-IWebHost- 'MutatorFX.Kraken.AspNetCore.WebHostingExtensions.UseKrakenStartupTask``1(Microsoft.AspNetCore.Hosting.IWebHost)')

<a name='T-MutatorFX-Kraken-AspNetCore-WebHostingExtensions'></a>
## WebHostingExtensions `type`

##### Namespace

MutatorFX.Kraken.AspNetCore

##### Summary

Contains extensions for configuring Kraken architecture application modules.

<a name='M-MutatorFX-Kraken-AspNetCore-WebHostingExtensions-UseKrakenModule``1-Microsoft-AspNetCore-Hosting-IWebHostBuilder-'></a>
### UseKrakenModule\`\`1(webHostBuilder) `method`

##### Summary

Configures a Kraken module to be used for the current `webHostBuilder`.

##### Returns

The `webHostBuilder`instance after configured by the [IKrakenModule](#T-MutatorFX-Kraken-AspNetCore-IKrakenModule 'MutatorFX.Kraken.AspNetCore.IKrakenModule').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| webHostBuilder | [Microsoft.AspNetCore.Hosting.IWebHostBuilder](#T-Microsoft-AspNetCore-Hosting-IWebHostBuilder 'Microsoft.AspNetCore.Hosting.IWebHostBuilder') | The [IWebHostBuilder](#T-Microsoft-AspNetCore-Hosting-IWebHostBuilder 'Microsoft.AspNetCore.Hosting.IWebHostBuilder')to use. Should not be null. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the [IKrakenModule](#T-MutatorFX-Kraken-AspNetCore-IKrakenModule 'MutatorFX.Kraken.AspNetCore.IKrakenModule')to use. A new object will be instantiated. |

<a name='M-MutatorFX-Kraken-AspNetCore-WebHostingExtensions-UseKrakenModule``1-Microsoft-AspNetCore-Hosting-IWebHostBuilder,``0-'></a>
### UseKrakenModule\`\`1(webHostBuilder,krakenModule) `method`

##### Summary

Configures a Kraken module to be used for the current `webHostBuilder`.

##### Returns

The `webHostBuilder`instance after configured by the [IKrakenModule](#T-MutatorFX-Kraken-AspNetCore-IKrakenModule 'MutatorFX.Kraken.AspNetCore.IKrakenModule').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| webHostBuilder | [Microsoft.AspNetCore.Hosting.IWebHostBuilder](#T-Microsoft-AspNetCore-Hosting-IWebHostBuilder 'Microsoft.AspNetCore.Hosting.IWebHostBuilder') | The [IWebHostBuilder](#T-Microsoft-AspNetCore-Hosting-IWebHostBuilder 'Microsoft.AspNetCore.Hosting.IWebHostBuilder')to use. Should not be null. |
| krakenModule | [\`\`0](#T-``0 '``0') | The module to configure the builder with. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the [IKrakenModule](#T-MutatorFX-Kraken-AspNetCore-IKrakenModule 'MutatorFX.Kraken.AspNetCore.IKrakenModule')to use. |

<a name='M-MutatorFX-Kraken-AspNetCore-WebHostingExtensions-UseKrakenStartupTask``1-Microsoft-AspNetCore-Hosting-IWebHost-'></a>
### UseKrakenStartupTask\`\`1(webHost) `method`

##### Summary

Execute an [IKrakenStartupTask](#T-MutatorFX-Kraken-AspNetCore-IKrakenStartupTask 'MutatorFX.Kraken.AspNetCore.IKrakenStartupTask')before hosting starts of an [IWebHost](#T-Microsoft-AspNetCore-Hosting-IWebHost 'Microsoft.AspNetCore.Hosting.IWebHost').

##### Returns

The `webHost`, after the startup task finished.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| webHost | [Microsoft.AspNetCore.Hosting.IWebHost](#T-Microsoft-AspNetCore-Hosting-IWebHost 'Microsoft.AspNetCore.Hosting.IWebHost') | The host to execute the startup task on. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the [IKrakenStartupTask](#T-MutatorFX-Kraken-AspNetCore-IKrakenStartupTask 'MutatorFX.Kraken.AspNetCore.IKrakenStartupTask')to use. Will be instantiated by using a service scope from the `webHost`'s [Services](#P-Microsoft-AspNetCore-Hosting-IWebHost-Services 'Microsoft.AspNetCore.Hosting.IWebHost.Services'). |
