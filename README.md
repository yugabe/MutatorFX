# MutatorFX

This repository contains work-in-progress code for framework functionality and is a candidate to be merged with the [QueryMutator](https://github.com/yugabe/QueryMutator) repo.

MutatorFX is currently available on [NuGet](https://www.nuget.org/packages?q=MutatorFX), altough still in early beta. Feel free to experiment, give feedback and contribute!

All MutatorFX packages lets you write much less code for the same effect, with a lot less room for developer error.

**MutatorFX** contains the following for all **.NET** based projects compatible with **.NET Standard 2.0**:

<hr/>

**MutatorFX.Core** [[NuGet](https://www.nuget.org/packages/MutatorFX.Core/), [Documentation](https://github.com/yugabe/MutatorFX/blob/master/docs/md/MutatorFX.Core.md)]
------------------
The lightweight Core package other packages depend upon. In itself, it contains useful extension methods for creating one-liners, using reflection, etc., so that you can use these if you fancy enormous one-liners! I haven't found a problem that couldn't be solved in one expression with these yet!

**Fluent extensions**: for writing one-liners and shortening code. 

**Reflection extensions**: commonly used framework functionality involving the Type object and other reflection goodies.

**MutatorFX.FilterMutator.Core** [[NuGet](https://www.nuget.org/packages/MutatorFX.FilterMutator.Core/), [Documentation](https://github.com/yugabe/MutatorFX/blob/master/docs/md/MutatorFX.FilterMutator.Core.md)]
--------------------------------
FilterMutator is an opinionated filtering framework in itself. It provides a composing mechanism to fully control how querying a data source works in your application. Compatible with all dependency injection frameworks. The main concepts you should get familiar with are ```Pager```s, ```Sorter```s, ```Transformer```s, ```SourceAccessor```s, ```Filterer```s and ```QueryExecutor```s as composition of these components. The MutatorFX.FilterMutator.Core package provides features to set up a consistent filtering schema in your application.

**MutatorFX.FilterMutator.Abstractions** [[NuGet](https://www.nuget.org/packages/MutatorFX.FilterMutator.Abstractions/), [Documentation](https://github.com/yugabe/MutatorFX/blob/master/docs/md/MutatorFX.FilterMutator.Abstractions.md)]
----------------------------------------
The abstractions package contains only the public facing interfaces of FilterMutator, so if you want to create a custom extension for FilterMutator for other frameworks or different use cases, you should only reference the abstractions package. If you create a package, don't hesitate to [create an issue](https://github.com/yugabe/MutatorFX/issues) so that I can list your package here!

**MutatorFX.FilterMutator.EFCore**: [[NuGet](https://www.nuget.org/packages/MutatorFX.FilterMutator.EFCore/), [Documentation](https://github.com/yugabe/MutatorFX/blob/master/docs/md/MutatorFX.FilterMutator.EFCore.md)]
----------------------------------
[Entity Framework Core](https://github.com/aspnet/EntityFrameworkCore) specific extension package. Only contains two SourceAccessor types (```DbSetSourceAccessor<TDbContext, TEntity>``` and ```DbSetSourceAccessor<TEntity>```) which you can use with EF Core and dependency injection frameworks.

**MutatorFX.QueryMutator.Core** [NuGet, [Documentation](https://github.com/yugabe/MutatorFX/blob/master/docs/md/MutatorFX.QueryMutator.Core.md)]
-------------------------------
TODO

<hr/>

Documentation generated with the [Vsxmd package](https://github.com/lijunle/Vsxmd), big thanks to [Li Junle](https://github.com/lijunle)!

**All contributions welcome! Happy hacking!**
