<a name='assembly'></a>
# MutatorFX.Kraken.AspNetCore

## Contents

- [WebHostBuilderExtensions](#T-MutatorFX-Kraken-AspNetCore-WebHostBuilderExtensions 'MutatorFX.Kraken.AspNetCore.WebHostBuilderExtensions')
  - [UseKrakenModule\`\`1(webHostBuilder)](#M-MutatorFX-Kraken-AspNetCore-WebHostBuilderExtensions-UseKrakenModule``1-Microsoft-AspNetCore-Hosting-IWebHostBuilder- 'MutatorFX.Kraken.AspNetCore.WebHostBuilderExtensions.UseKrakenModule``1(Microsoft.AspNetCore.Hosting.IWebHostBuilder)')
  - [UseKrakenModule\`\`1(webHostBuilder,krakenModule)](#M-MutatorFX-Kraken-AspNetCore-WebHostBuilderExtensions-UseKrakenModule``1-Microsoft-AspNetCore-Hosting-IWebHostBuilder,``0- 'MutatorFX.Kraken.AspNetCore.WebHostBuilderExtensions.UseKrakenModule``1(Microsoft.AspNetCore.Hosting.IWebHostBuilder,``0)')
  - [UseKrakenModule\`\`2(webHostBuilder)](#M-MutatorFX-Kraken-AspNetCore-WebHostBuilderExtensions-UseKrakenModule``2-``1- 'MutatorFX.Kraken.AspNetCore.WebHostBuilderExtensions.UseKrakenModule``2(``1)')
  - [UseKrakenModule\`\`2(webHostBuilder,krakenModule)](#M-MutatorFX-Kraken-AspNetCore-WebHostBuilderExtensions-UseKrakenModule``2-``1,``0- 'MutatorFX.Kraken.AspNetCore.WebHostBuilderExtensions.UseKrakenModule``2(``1,``0)')

<a name='T-MutatorFX-Kraken-AspNetCore-WebHostBuilderExtensions'></a>
## WebHostBuilderExtensions `type`

##### Namespace

MutatorFX.Kraken.AspNetCore

##### Summary

Contains extensions for configuring Kraken architecture application modules.

<a name='M-MutatorFX-Kraken-AspNetCore-WebHostBuilderExtensions-UseKrakenModule``1-Microsoft-AspNetCore-Hosting-IWebHostBuilder-'></a>
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

<a name='M-MutatorFX-Kraken-AspNetCore-WebHostBuilderExtensions-UseKrakenModule``1-Microsoft-AspNetCore-Hosting-IWebHostBuilder,``0-'></a>
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

<a name='M-MutatorFX-Kraken-AspNetCore-WebHostBuilderExtensions-UseKrakenModule``2-``1-'></a>
### UseKrakenModule\`\`2(webHostBuilder) `method`

##### Summary

Configures a Kraken module to be used for the current `webHostBuilder`.

##### Returns

The `webHostBuilder`instance after configured by the [IKrakenModule](#T-MutatorFX-Kraken-AspNetCore-IKrakenModule 'MutatorFX.Kraken.AspNetCore.IKrakenModule').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| webHostBuilder | [\`\`1](#T-``1 '``1') | The [IWebHostBuilder](#T-Microsoft-AspNetCore-Hosting-IWebHostBuilder 'Microsoft.AspNetCore.Hosting.IWebHostBuilder')to use. Should not be null. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the [IKrakenModule](#T-MutatorFX-Kraken-AspNetCore-IKrakenModule 'MutatorFX.Kraken.AspNetCore.IKrakenModule')to use. A new object will be instantiated. |
| TBuilder | The type of the builder. Should be inferred. |

<a name='M-MutatorFX-Kraken-AspNetCore-WebHostBuilderExtensions-UseKrakenModule``2-``1,``0-'></a>
### UseKrakenModule\`\`2(webHostBuilder,krakenModule) `method`

##### Summary

Configures a Kraken module to be used for the current `webHostBuilder`.

##### Returns

The `webHostBuilder`instance after configured by the [IKrakenModule](#T-MutatorFX-Kraken-AspNetCore-IKrakenModule 'MutatorFX.Kraken.AspNetCore.IKrakenModule').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| webHostBuilder | [\`\`1](#T-``1 '``1') | The [IWebHostBuilder](#T-Microsoft-AspNetCore-Hosting-IWebHostBuilder 'Microsoft.AspNetCore.Hosting.IWebHostBuilder')to use. Should not be null. |
| krakenModule | [\`\`0](#T-``0 '``0') | The module to configure the builder with. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the [IKrakenModule](#T-MutatorFX-Kraken-AspNetCore-IKrakenModule 'MutatorFX.Kraken.AspNetCore.IKrakenModule')to use. |
| TBuilder | The type of the builder. Should be inferred. |
