<a name='assembly'></a>
# MutatorFX.Kraken.AspNetCore.EntityFrameworkCore.SqlServer

## Contents

- [MigrateSqlDatabase\`1](#T-MutatorFX-Kraken-AspNetCore-EntityFrameworkCore-SqlServer-MigrateSqlDatabase`1 'MutatorFX.Kraken.AspNetCore.EntityFrameworkCore.SqlServer.MigrateSqlDatabase`1')
  - [#ctor(dbContext)](#M-MutatorFX-Kraken-AspNetCore-EntityFrameworkCore-SqlServer-MigrateSqlDatabase`1-#ctor-`0- 'MutatorFX.Kraken.AspNetCore.EntityFrameworkCore.SqlServer.MigrateSqlDatabase`1.#ctor(`0)')
  - [DbContext](#P-MutatorFX-Kraken-AspNetCore-EntityFrameworkCore-SqlServer-MigrateSqlDatabase`1-DbContext 'MutatorFX.Kraken.AspNetCore.EntityFrameworkCore.SqlServer.MigrateSqlDatabase`1.DbContext')
  - [OnBeforeHostStartsAsync(webHost)](#M-MutatorFX-Kraken-AspNetCore-EntityFrameworkCore-SqlServer-MigrateSqlDatabase`1-OnBeforeHostStartsAsync-Microsoft-AspNetCore-Hosting-IWebHost- 'MutatorFX.Kraken.AspNetCore.EntityFrameworkCore.SqlServer.MigrateSqlDatabase`1.OnBeforeHostStartsAsync(Microsoft.AspNetCore.Hosting.IWebHost)')
- [WebHostingExtensions](#T-MutatorFX-Kraken-AspNetCore-EntityFrameworkCore-SqlServer-WebHostingExtensions 'MutatorFX.Kraken.AspNetCore.EntityFrameworkCore.SqlServer.WebHostingExtensions')
  - [MigrateSqlDatabase(webHost)](#M-MutatorFX-Kraken-AspNetCore-EntityFrameworkCore-SqlServer-WebHostingExtensions-MigrateSqlDatabase-Microsoft-AspNetCore-Hosting-IWebHost- 'MutatorFX.Kraken.AspNetCore.EntityFrameworkCore.SqlServer.WebHostingExtensions.MigrateSqlDatabase(Microsoft.AspNetCore.Hosting.IWebHost)')
  - [MigrateSqlDatabase\`\`1(webHost)](#M-MutatorFX-Kraken-AspNetCore-EntityFrameworkCore-SqlServer-WebHostingExtensions-MigrateSqlDatabase``1-Microsoft-AspNetCore-Hosting-IWebHost- 'MutatorFX.Kraken.AspNetCore.EntityFrameworkCore.SqlServer.WebHostingExtensions.MigrateSqlDatabase``1(Microsoft.AspNetCore.Hosting.IWebHost)')

<a name='T-MutatorFX-Kraken-AspNetCore-EntityFrameworkCore-SqlServer-MigrateSqlDatabase`1'></a>
## MigrateSqlDatabase\`1 `type`

##### Namespace

MutatorFX.Kraken.AspNetCore.EntityFrameworkCore.SqlServer

##### Summary

A startup task that calls [Migrate](#M-Microsoft-EntityFrameworkCore-RelationalDatabaseFacadeExtensions-Migrate-Microsoft-EntityFrameworkCore-Infrastructure-DatabaseFacade- 'Microsoft.EntityFrameworkCore.RelationalDatabaseFacadeExtensions.Migrate(Microsoft.EntityFrameworkCore.Infrastructure.DatabaseFacade)')on a `TDbContext`instance.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TDbContext | The type of the [DbContext](#T-Microsoft-EntityFrameworkCore-DbContext 'Microsoft.EntityFrameworkCore.DbContext')to use. |

<a name='M-MutatorFX-Kraken-AspNetCore-EntityFrameworkCore-SqlServer-MigrateSqlDatabase`1-#ctor-`0-'></a>
### #ctor(dbContext) `constructor`

##### Summary

Create a new task that can migrate the database.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dbContext | [\`0](#T-`0 '`0') | The instance of `TDbContext`to use for applying migrations. |

<a name='P-MutatorFX-Kraken-AspNetCore-EntityFrameworkCore-SqlServer-MigrateSqlDatabase`1-DbContext'></a>
### DbContext `property`

##### Summary

The instance of `TDbContext`to use for applying migrations.

<a name='M-MutatorFX-Kraken-AspNetCore-EntityFrameworkCore-SqlServer-MigrateSqlDatabase`1-OnBeforeHostStartsAsync-Microsoft-AspNetCore-Hosting-IWebHost-'></a>
### OnBeforeHostStartsAsync(webHost) `method`

##### Summary

Applies all migrations to the database.

##### Returns

A completed task.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| webHost | [Microsoft.AspNetCore.Hosting.IWebHost](#T-Microsoft-AspNetCore-Hosting-IWebHost 'Microsoft.AspNetCore.Hosting.IWebHost') | The host to use for migrations. |

<a name='T-MutatorFX-Kraken-AspNetCore-EntityFrameworkCore-SqlServer-WebHostingExtensions'></a>
## WebHostingExtensions `type`

##### Namespace

MutatorFX.Kraken.AspNetCore.EntityFrameworkCore.SqlServer

##### Summary

Contains extensions for configuring the [IWebHost](#T-Microsoft-AspNetCore-Hosting-IWebHost 'Microsoft.AspNetCore.Hosting.IWebHost')with Kraken modules and services.

<a name='M-MutatorFX-Kraken-AspNetCore-EntityFrameworkCore-SqlServer-WebHostingExtensions-MigrateSqlDatabase-Microsoft-AspNetCore-Hosting-IWebHost-'></a>
### MigrateSqlDatabase(webHost) `method`

##### Summary

Migrate an SQL database using Entity Framework Core migrations with the default [DbContext](#T-Microsoft-EntityFrameworkCore-DbContext 'Microsoft.EntityFrameworkCore.DbContext').

##### Returns

The `webHost`, after the startup task finished.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| webHost | [Microsoft.AspNetCore.Hosting.IWebHost](#T-Microsoft-AspNetCore-Hosting-IWebHost 'Microsoft.AspNetCore.Hosting.IWebHost') | The host to execute the startup task on. |

<a name='M-MutatorFX-Kraken-AspNetCore-EntityFrameworkCore-SqlServer-WebHostingExtensions-MigrateSqlDatabase``1-Microsoft-AspNetCore-Hosting-IWebHost-'></a>
### MigrateSqlDatabase\`\`1(webHost) `method`

##### Summary

Migrate an SQL database using Entity Framework Core migrations with a given [DbContext](#T-Microsoft-EntityFrameworkCore-DbContext 'Microsoft.EntityFrameworkCore.DbContext')type.

##### Returns

The `webHost`, after the startup task finished.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| webHost | [Microsoft.AspNetCore.Hosting.IWebHost](#T-Microsoft-AspNetCore-Hosting-IWebHost 'Microsoft.AspNetCore.Hosting.IWebHost') | The host to execute the startup task on. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of DbContext to use for migrations. |
