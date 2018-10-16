<a name='assembly'></a>
# MutatorFX.FilterMutator.Abstractions

## Contents

- [IFilterClause\`2](#T-MutatorFX-FilterMutator-IFilterClause`2 'MutatorFX.FilterMutator.IFilterClause`2')
  - [ClauseExpression](#P-MutatorFX-FilterMutator-IFilterClause`2-ClauseExpression 'MutatorFX.FilterMutator.IFilterClause`2.ClauseExpression')
  - [Execute(source,filter)](#M-MutatorFX-FilterMutator-IFilterClause`2-Execute-System-Linq-IQueryable{`0},`1- 'MutatorFX.FilterMutator.IFilterClause`2.Execute(System.Linq.IQueryable{`0},`1)')
  - [GetClause(filter)](#M-MutatorFX-FilterMutator-IFilterClause`2-GetClause-`1- 'MutatorFX.FilterMutator.IFilterClause`2.GetClause(`1)')
  - [GetFilterPredicate(filter)](#M-MutatorFX-FilterMutator-IFilterClause`2-GetFilterPredicate-`1- 'MutatorFX.FilterMutator.IFilterClause`2.GetFilterPredicate(`1)')
  - [GetOnDisabledFilterPredicate()](#M-MutatorFX-FilterMutator-IFilterClause`2-GetOnDisabledFilterPredicate 'MutatorFX.FilterMutator.IFilterClause`2.GetOnDisabledFilterPredicate')
  - [IsClauseEnabled(filter)](#M-MutatorFX-FilterMutator-IFilterClause`2-IsClauseEnabled-`1- 'MutatorFX.FilterMutator.IFilterClause`2.IsClauseEnabled(`1)')
- [IFilterer\`2](#T-MutatorFX-FilterMutator-IFilterer`2 'MutatorFX.FilterMutator.IFilterer`2')
  - [Filter(source,filter)](#M-MutatorFX-FilterMutator-IFilterer`2-Filter-System-Linq-IQueryable{`0},`1- 'MutatorFX.FilterMutator.IFilterer`2.Filter(System.Linq.IQueryable{`0},`1)')
- [IPager\`1](#T-MutatorFX-FilterMutator-IPager`1 'MutatorFX.FilterMutator.IPager`1')
  - [Page(source,page,pageSize)](#M-MutatorFX-FilterMutator-IPager`1-Page-System-Linq-IQueryable{`0},System-Int32,System-Int32- 'MutatorFX.FilterMutator.IPager`1.Page(System.Linq.IQueryable{`0},System.Int32,System.Int32)')
- [IQueryExecutor\`3](#T-MutatorFX-FilterMutator-IQueryExecutor`3 'MutatorFX.FilterMutator.IQueryExecutor`3')
  - [ExecuteQuery(filter,page,pageSize,sorting,sortDescending)](#M-MutatorFX-FilterMutator-IQueryExecutor`3-ExecuteQuery-`0,System-Int32,System-Int32,`1,System-Boolean- 'MutatorFX.FilterMutator.IQueryExecutor`3.ExecuteQuery(`0,System.Int32,System.Int32,`1,System.Boolean)')
- [ISorter\`2](#T-MutatorFX-FilterMutator-ISorter`2 'MutatorFX.FilterMutator.ISorter`2')
  - [Sort(filtered,sort,sortDescending)](#M-MutatorFX-FilterMutator-ISorter`2-Sort-System-Linq-IQueryable{`0},`1,System-Boolean- 'MutatorFX.FilterMutator.ISorter`2.Sort(System.Linq.IQueryable{`0},`1,System.Boolean)')
- [ISourceAccessor\`1](#T-MutatorFX-FilterMutator-ISourceAccessor`1 'MutatorFX.FilterMutator.ISourceAccessor`1')
  - [Source](#P-MutatorFX-FilterMutator-ISourceAccessor`1-Source 'MutatorFX.FilterMutator.ISourceAccessor`1.Source')
- [ITransformer\`2](#T-MutatorFX-FilterMutator-ITransformer`2 'MutatorFX.FilterMutator.ITransformer`2')
  - [Transform(source)](#M-MutatorFX-FilterMutator-ITransformer`2-Transform-System-Linq-IQueryable{`0}- 'MutatorFX.FilterMutator.ITransformer`2.Transform(System.Linq.IQueryable{`0})')
- [PagedResult\`1](#T-MutatorFX-FilterMutator-PagedResult`1 'MutatorFX.FilterMutator.PagedResult`1')
  - [#ctor(results,page,pageSize,totalItems)](#M-MutatorFX-FilterMutator-PagedResult`1-#ctor-System-Collections-Generic-IReadOnlyList{`0},System-Int32,System-Int32,System-Int32- 'MutatorFX.FilterMutator.PagedResult`1.#ctor(System.Collections.Generic.IReadOnlyList{`0},System.Int32,System.Int32,System.Int32)')
  - [Page](#P-MutatorFX-FilterMutator-PagedResult`1-Page 'MutatorFX.FilterMutator.PagedResult`1.Page')
  - [PageSize](#P-MutatorFX-FilterMutator-PagedResult`1-PageSize 'MutatorFX.FilterMutator.PagedResult`1.PageSize')
  - [Results](#P-MutatorFX-FilterMutator-PagedResult`1-Results 'MutatorFX.FilterMutator.PagedResult`1.Results')
  - [TotalItems](#P-MutatorFX-FilterMutator-PagedResult`1-TotalItems 'MutatorFX.FilterMutator.PagedResult`1.TotalItems')

<a name='T-MutatorFX-FilterMutator-IFilterClause`2'></a>
## IFilterClause\`2 `type`

##### Namespace

MutatorFX.FilterMutator

##### Summary

The common interface for clauses that can describe elements in a filter object.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The source object type which filtering occurs on. |
| TFilter | The type of the filter used for filtering. |

<a name='P-MutatorFX-FilterMutator-IFilterClause`2-ClauseExpression'></a>
### ClauseExpression `property`

##### Summary

The expression which selects the clause. It is usually a [LambdaExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.LambdaExpression 'System.Linq.Expressions.LambdaExpression'), which encapsulates a [Func\`2](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func`2 'System.Func`2')delegate.

<a name='M-MutatorFX-FilterMutator-IFilterClause`2-Execute-System-Linq-IQueryable{`0},`1-'></a>
### Execute(source,filter) `method`

##### Summary

Executes the clause on the given IQueryable datasource.

##### Returns

The filtered dataset, represented by a queryable object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{`0}') | The source dataset to filter. |
| filter | [\`1](#T-`1 '`1') | The filter to apply to the dataset for this clause. |

<a name='M-MutatorFX-FilterMutator-IFilterClause`2-GetClause-`1-'></a>
### GetClause(filter) `method`

##### Summary

The value of the clause selected from the filter by the [ClauseExpression](#P-MutatorFX-FilterMutator-IFilterClause`2-ClauseExpression 'MutatorFX.FilterMutator.IFilterClause`2.ClauseExpression').

##### Returns

The value of the clause, as returned by the clause selector ([ClauseExpression](#P-MutatorFX-FilterMutator-IFilterClause`2-ClauseExpression 'MutatorFX.FilterMutator.IFilterClause`2.ClauseExpression')).

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filter | [\`1](#T-`1 '`1') | The filter to get the clause from. |

<a name='M-MutatorFX-FilterMutator-IFilterClause`2-GetFilterPredicate-`1-'></a>
### GetFilterPredicate(filter) `method`

##### Summary

The predicate that can be passed to the filtering function.

##### Returns

An expression encapsulating a predicate typed delegate, which determines whether an element
matches the given clause for the given filter values or not.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filter | [\`1](#T-`1 '`1') | The filter to use the values from. Can also use the clause selector expression 
to get the clause value and check whether the clause is enabled. |

<a name='M-MutatorFX-FilterMutator-IFilterClause`2-GetOnDisabledFilterPredicate'></a>
### GetOnDisabledFilterPredicate() `method`

##### Summary

A fallback expression that should be used when a cluase is disabled. A good default can be a function
that returns the constant true value, thus not filtering the input set of data.

##### Returns

The fallback expression to use when the clause is disabled.

##### Parameters

This method has no parameters.

<a name='M-MutatorFX-FilterMutator-IFilterClause`2-IsClauseEnabled-`1-'></a>
### IsClauseEnabled(filter) `method`

##### Summary

Indicates whether the clause is enabled or not on a given filter.

##### Returns

True if the clause is enabled and should be evaluated.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filter | [\`1](#T-`1 '`1') | The filter to check to determine whether the clause is enabled or not. |

<a name='T-MutatorFX-FilterMutator-IFilterer`2'></a>
## IFilterer\`2 `type`

##### Namespace

MutatorFX.FilterMutator

##### Summary

The interface which represents an object that can apply filtering to a dataset.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The source type to apply filtering to. |
| TFilter | The filter type to use when filtering. |

<a name='M-MutatorFX-FilterMutator-IFilterer`2-Filter-System-Linq-IQueryable{`0},`1-'></a>
### Filter(source,filter) `method`

##### Summary

Filter a given dataset with a given filter object.

##### Returns

The filtered dataset, represented by a queryable object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{`0}') | The source to apply filtering to. |
| filter | [\`1](#T-`1 '`1') | The filter to use for filtering. |

<a name='T-MutatorFX-FilterMutator-IPager`1'></a>
## IPager\`1 `type`

##### Namespace

MutatorFX.FilterMutator

##### Summary

Represents an object which can create a paged result in the form of a queryable object.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TResult | The type of the elements in the resultset. |

<a name='M-MutatorFX-FilterMutator-IPager`1-Page-System-Linq-IQueryable{`0},System-Int32,System-Int32-'></a>
### Page(source,page,pageSize) `method`

##### Summary

Apply paging to a queryable object. The source should refer to the full dataset to be paged.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{`0}') | The source objects represented in the form of a queryable object. |
| page | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The 1-based page number requested. Should be positive. |
| pageSize | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The size of the page requested. Should be positive. |

<a name='T-MutatorFX-FilterMutator-IQueryExecutor`3'></a>
## IQueryExecutor\`3 `type`

##### Namespace

MutatorFX.FilterMutator

##### Summary

Represents an object which can filter, page and sort a dataset.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFilter | The filter object type to use for filtering. |
| TSort | The sorting enum type to use when ordering the resultset. |
| TResult | The type of the objects included in the paged result object. |

<a name='M-MutatorFX-FilterMutator-IQueryExecutor`3-ExecuteQuery-`0,System-Int32,System-Int32,`1,System-Boolean-'></a>
### ExecuteQuery(filter,page,pageSize,sorting,sortDescending) `method`

##### Summary

Executes filtering on a source dataset with the given parameters.

##### Returns

The filtered, sorted and paged resultset and paging metadata.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filter | [\`0](#T-`0 '`0') | The filter object used to filter the source dataset. |
| page | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The 1-based page number to use for paging the results. |
| pageSize | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The size of the page to use for paging the results. |
| sorting | [\`1](#T-`1 '`1') | The sorting value to use when querying the source dataset. |
| sortDescending | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | The order of sorting to use when querying the source dataset. |

<a name='T-MutatorFX-FilterMutator-ISorter`2'></a>
## ISorter\`2 `type`

##### Namespace

MutatorFX.FilterMutator

##### Summary

Represents an implementation of a sorting algorithm based on a typed enum.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The source item type to sort. |
| TSort |  |

<a name='M-MutatorFX-FilterMutator-ISorter`2-Sort-System-Linq-IQueryable{`0},`1,System-Boolean-'></a>
### Sort(filtered,sort,sortDescending) `method`

##### Summary

Sort a given dataset by the provided sort enum value and order.

##### Returns

The sorted queryable object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filtered | [System.Linq.IQueryable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{`0}') | The filtered dataset to sort. |
| sort | [\`1](#T-`1 '`1') | The sort value to sort the dataset by. |
| sortDescending | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Whether to order the resultset in descending or ascending order. |

<a name='T-MutatorFX-FilterMutator-ISourceAccessor`1'></a>
## ISourceAccessor\`1 `type`

##### Namespace

MutatorFX.FilterMutator

##### Summary

Represents an object that can provide an [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1')datasource.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The type of the elements in the source dataset. |

<a name='P-MutatorFX-FilterMutator-ISourceAccessor`1-Source'></a>
### Source `property`

##### Summary

The `TSource`elements, represented by a queryable object.

<a name='T-MutatorFX-FilterMutator-ITransformer`2'></a>
## ITransformer\`2 `type`

##### Namespace

MutatorFX.FilterMutator

##### Summary

Represents a transformation between the types `TSource`and `TResult`.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The source type to transform objects from. |
| TResult | The result type to transform objects to. |

<a name='M-MutatorFX-FilterMutator-ITransformer`2-Transform-System-Linq-IQueryable{`0}-'></a>
### Transform(source) `method`

##### Summary

Apply a transformation to a queryable of source objects, which produce a queryable of result objects.

##### Returns

The transformed elements of `TSource`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{`0}') | The source queryable to transform. |

<a name='T-MutatorFX-FilterMutator-PagedResult`1'></a>
## PagedResult\`1 `type`

##### Namespace

MutatorFX.FilterMutator

##### Summary

An encapsulating object, which can provide a set of results and paging metadata.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TResult | The type of the objects in the result dataset. |

<a name='M-MutatorFX-FilterMutator-PagedResult`1-#ctor-System-Collections-Generic-IReadOnlyList{`0},System-Int32,System-Int32,System-Int32-'></a>
### #ctor(results,page,pageSize,totalItems) `constructor`

##### Summary

Create a PagedResult object, which sets all relevant paging metadata for the given resultset.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| results | [System.Collections.Generic.IReadOnlyList{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyList 'System.Collections.Generic.IReadOnlyList{`0}') | The results to contain with this paging object. |
| page | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The page the relevant results are listed for. |
| pageSize | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The size of the page for which the relevant results are listed for. |
| totalItems | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The number of total items for which this object contains one page of. |

<a name='P-MutatorFX-FilterMutator-PagedResult`1-Page'></a>
### Page `property`

##### Summary

The page of results this object represents.

<a name='P-MutatorFX-FilterMutator-PagedResult`1-PageSize'></a>
### PageSize `property`

##### Summary

The size of the page for the results this object represents.

<a name='P-MutatorFX-FilterMutator-PagedResult`1-Results'></a>
### Results `property`

##### Summary

The results contained on the page represented by this object.

<a name='P-MutatorFX-FilterMutator-PagedResult`1-TotalItems'></a>
### TotalItems `property`

##### Summary

The total number of source items regarding the current objects paging metadata.
