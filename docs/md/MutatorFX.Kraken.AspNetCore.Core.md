<a name='assembly'></a>
# MutatorFX.Kraken.AspNetCore.Core

## Contents

- [IKrakenModule](#T-MutatorFX-Kraken-AspNetCore-IKrakenModule 'MutatorFX.Kraken.AspNetCore.IKrakenModule')
  - [Configure(services,configuration,hostingEnvironment,loggingBuilder)](#M-MutatorFX-Kraken-AspNetCore-IKrakenModule-Configure-Microsoft-Extensions-DependencyInjection-IServiceCollection,Microsoft-Extensions-Configuration-IConfiguration,Microsoft-AspNetCore-Hosting-IHostingEnvironment,Microsoft-Extensions-Logging-ILoggingBuilder- 'MutatorFX.Kraken.AspNetCore.IKrakenModule.Configure(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration,Microsoft.AspNetCore.Hosting.IHostingEnvironment,Microsoft.Extensions.Logging.ILoggingBuilder)')
- [IKrakenStartupTask](#T-MutatorFX-Kraken-AspNetCore-IKrakenStartupTask 'MutatorFX.Kraken.AspNetCore.IKrakenStartupTask')
  - [OnBeforeHostStartsAsync(webHost)](#M-MutatorFX-Kraken-AspNetCore-IKrakenStartupTask-OnBeforeHostStartsAsync-Microsoft-AspNetCore-Hosting-IWebHost- 'MutatorFX.Kraken.AspNetCore.IKrakenStartupTask.OnBeforeHostStartsAsync(Microsoft.AspNetCore.Hosting.IWebHost)')

<a name='T-MutatorFX-Kraken-AspNetCore-IKrakenModule'></a>
## IKrakenModule `type`

##### Namespace

MutatorFX.Kraken.AspNetCore

##### Summary

A module that is used to wire up different featuresets to an application.

<a name='M-MutatorFX-Kraken-AspNetCore-IKrakenModule-Configure-Microsoft-Extensions-DependencyInjection-IServiceCollection,Microsoft-Extensions-Configuration-IConfiguration,Microsoft-AspNetCore-Hosting-IHostingEnvironment,Microsoft-Extensions-Logging-ILoggingBuilder-'></a>
### Configure(services,configuration,hostingEnvironment,loggingBuilder) `method`

##### Summary

Used to configure an application's dependency injection, configuration and logging based on the hosting environment.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| services | [Microsoft.Extensions.DependencyInjection.IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') | The dependency injection services to configure. Features should only provide services pertaining to their featuresets. |
| configuration | [Microsoft.Extensions.Configuration.IConfiguration](#T-Microsoft-Extensions-Configuration-IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') | The configuration object to configure. |
| hostingEnvironment | [Microsoft.AspNetCore.Hosting.IHostingEnvironment](#T-Microsoft-AspNetCore-Hosting-IHostingEnvironment 'Microsoft.AspNetCore.Hosting.IHostingEnvironment') | The environment of the application. Can be used to switch different implementations for services, logging and so on. |
| loggingBuilder | [Microsoft.Extensions.Logging.ILoggingBuilder](#T-Microsoft-Extensions-Logging-ILoggingBuilder 'Microsoft.Extensions.Logging.ILoggingBuilder') | Used to configure different logging objects for the application. Should be scoped to the module's featureset. |

<a name='T-MutatorFX-Kraken-AspNetCore-IKrakenStartupTask'></a>
## IKrakenStartupTask `type`

##### Namespace

MutatorFX.Kraken.AspNetCore

##### Summary

Represents a startup task that gets executed before hosting starts.

<a name='M-MutatorFX-Kraken-AspNetCore-IKrakenStartupTask-OnBeforeHostStartsAsync-Microsoft-AspNetCore-Hosting-IWebHost-'></a>
### OnBeforeHostStartsAsync(webHost) `method`

##### Summary

The task to execute before hosting starts on the `webHost`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| webHost | [Microsoft.AspNetCore.Hosting.IWebHost](#T-Microsoft-AspNetCore-Hosting-IWebHost 'Microsoft.AspNetCore.Hosting.IWebHost') | The [IWebHost](#T-Microsoft-AspNetCore-Hosting-IWebHost 'Microsoft.AspNetCore.Hosting.IWebHost')to use. |
