<a name='assembly'></a>
# MutatorFX.FilterMutator.EFCore

## Contents

- [DbSetSourceAccessor\`1](#T-MutatorFX-FilterMutator-EFCore-DbSetSourceAccessor`1 'MutatorFX.FilterMutator.EFCore.DbSetSourceAccessor`1')
  - [#ctor(dbContext)](#M-MutatorFX-FilterMutator-EFCore-DbSetSourceAccessor`1-#ctor-Microsoft-EntityFrameworkCore-DbContext- 'MutatorFX.FilterMutator.EFCore.DbSetSourceAccessor`1.#ctor(Microsoft.EntityFrameworkCore.DbContext)')
- [DbSetSourceAccessor\`2](#T-MutatorFX-FilterMutator-EFCore-DbSetSourceAccessor`2 'MutatorFX.FilterMutator.EFCore.DbSetSourceAccessor`2')
  - [#ctor(dbContext)](#M-MutatorFX-FilterMutator-EFCore-DbSetSourceAccessor`2-#ctor-`0- 'MutatorFX.FilterMutator.EFCore.DbSetSourceAccessor`2.#ctor(`0)')
  - [DbContext](#P-MutatorFX-FilterMutator-EFCore-DbSetSourceAccessor`2-DbContext 'MutatorFX.FilterMutator.EFCore.DbSetSourceAccessor`2.DbContext')
  - [Source](#P-MutatorFX-FilterMutator-EFCore-DbSetSourceAccessor`2-Source 'MutatorFX.FilterMutator.EFCore.DbSetSourceAccessor`2.Source')

<a name='T-MutatorFX-FilterMutator-EFCore-DbSetSourceAccessor`1'></a>
## DbSetSourceAccessor\`1 `type`

##### Namespace

MutatorFX.FilterMutator.EFCore

##### Summary

A [DbSetSourceAccessor\`2](#T-MutatorFX-FilterMutator-EFCore-DbSetSourceAccessor`2 'MutatorFX.FilterMutator.EFCore.DbSetSourceAccessor`2'), which accepts any [DbContext](#T-Microsoft-EntityFrameworkCore-DbContext 'Microsoft.EntityFrameworkCore.DbContext') as the [DbSet\`1](#T-Microsoft-EntityFrameworkCore-DbSet`1 'Microsoft.EntityFrameworkCore.DbSet`1')'s accessor.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TEntity | The entity type used in accessing the [DbContext](#T-Microsoft-EntityFrameworkCore-DbContext 'Microsoft.EntityFrameworkCore.DbContext')'s [Set\`\`1](#M-Microsoft-EntityFrameworkCore-DbContext-Set``1 'Microsoft.EntityFrameworkCore.DbContext.Set``1') method. |

<a name='M-MutatorFX-FilterMutator-EFCore-DbSetSourceAccessor`1-#ctor-Microsoft-EntityFrameworkCore-DbContext-'></a>
### #ctor(dbContext) `constructor`

##### Summary

Create an instance of this class with the given context to use when accessing its `TEntity`[DbSet\`1](#T-Microsoft-EntityFrameworkCore-DbSet`1 'Microsoft.EntityFrameworkCore.DbSet`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dbContext | [Microsoft.EntityFrameworkCore.DbContext](#T-Microsoft-EntityFrameworkCore-DbContext 'Microsoft.EntityFrameworkCore.DbContext') | The context to use to access the [DbSet\`1](#T-Microsoft-EntityFrameworkCore-DbSet`1 'Microsoft.EntityFrameworkCore.DbSet`1'). |

<a name='T-MutatorFX-FilterMutator-EFCore-DbSetSourceAccessor`2'></a>
## DbSetSourceAccessor\`2 `type`

##### Namespace

MutatorFX.FilterMutator.EFCore

##### Summary

An [ISourceAccessor\`1](#T-MutatorFX-FilterMutator-ISourceAccessor`1 'MutatorFX.FilterMutator.ISourceAccessor`1'), which provides the given entity type `TEntity` from a [DbContext](#T-Microsoft-EntityFrameworkCore-DbContext 'Microsoft.EntityFrameworkCore.DbContext')`TDbContext`.
            Uses the context's [Set\`\`1](#M-Microsoft-EntityFrameworkCore-DbContext-Set``1 'Microsoft.EntityFrameworkCore.DbContext.Set``1') method to access the queryable datasource.
            For single type parameter matching (i.e. when using dependency injection with unbound generics), inherit from this type and constrain the `TDbContext` type. 
            Alternatively, you can use the [DbSetSourceAccessor\`1](#T-MutatorFX-FilterMutator-EFCore-DbSetSourceAccessor`1 'MutatorFX.FilterMutator.EFCore.DbSetSourceAccessor`1') type which inherits from this type with the base [DbContext](#T-Microsoft-EntityFrameworkCore-DbContext 'Microsoft.EntityFrameworkCore.DbContext') implementation as `TDbContext`.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TDbContext | The context used to access the data source. |
| TEntity | The entity type which is used to access the context's [DbSet\`1](#T-Microsoft-EntityFrameworkCore-DbSet`1 'Microsoft.EntityFrameworkCore.DbSet`1'). |

<a name='M-MutatorFX-FilterMutator-EFCore-DbSetSourceAccessor`2-#ctor-`0-'></a>
### #ctor(dbContext) `constructor`

##### Summary

Create an instance of this class with the given context to use when accessing its `TEntity`[DbSet\`1](#T-Microsoft-EntityFrameworkCore-DbSet`1 'Microsoft.EntityFrameworkCore.DbSet`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dbContext | [\`0](#T-`0 '`0') | The context to use to access the [DbSet\`1](#T-Microsoft-EntityFrameworkCore-DbSet`1 'Microsoft.EntityFrameworkCore.DbSet`1'). |

<a name='P-MutatorFX-FilterMutator-EFCore-DbSetSourceAccessor`2-DbContext'></a>
### DbContext `property`

##### Summary

The context used to access the datasource queryable.

<a name='P-MutatorFX-FilterMutator-EFCore-DbSetSourceAccessor`2-Source'></a>
### Source `property`

##### Summary

The source dataset accessor. Uses the [DbContext](#P-MutatorFX-FilterMutator-EFCore-DbSetSourceAccessor`2-DbContext 'MutatorFX.FilterMutator.EFCore.DbSetSourceAccessor`2.DbContext')'s [Set\`\`1](#M-Microsoft-EntityFrameworkCore-DbContext-Set``1 'Microsoft.EntityFrameworkCore.DbContext.Set``1') method for access.
