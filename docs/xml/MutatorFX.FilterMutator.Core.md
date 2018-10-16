<a name='assembly'></a>
# MutatorFX.FilterMutator.Core

## Contents

- [AscDescSorterBase\`2](#T-MutatorFX-FilterMutator-AscDescSorterBase`2 'MutatorFX.FilterMutator.AscDescSorterBase`2')
  - [KeySelector(sort)](#M-MutatorFX-FilterMutator-AscDescSorterBase`2-KeySelector-`1- 'MutatorFX.FilterMutator.AscDescSorterBase`2.KeySelector(`1)')
  - [Sort(filtered,sort,sortDescending)](#M-MutatorFX-FilterMutator-AscDescSorterBase`2-Sort-System-Linq-IQueryable{`0},`1,System-Boolean- 'MutatorFX.FilterMutator.AscDescSorterBase`2.Sort(System.Linq.IQueryable{`0},`1,System.Boolean)')
- [ClauseCollection\`2](#T-MutatorFX-FilterMutator-ClauseCollection`2 'MutatorFX.FilterMutator.ClauseCollection`2')
  - [Clauses](#P-MutatorFX-FilterMutator-ClauseCollection`2-Clauses 'MutatorFX.FilterMutator.ClauseCollection`2.Clauses')
  - [AddClause\`\`1(filterClauseSelector,filterPredicate,onDisabledFilterPredicate,isClauseEnabled,options)](#M-MutatorFX-FilterMutator-ClauseCollection`2-AddClause``1-System-Linq-Expressions-Expression{System-Func{`1,``0}},System-Func{``0,System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}}},System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{`1,System-Boolean},System-ValueTuple{System-String,System-Object}[]- 'MutatorFX.FilterMutator.ClauseCollection`2.AddClause``1(System.Linq.Expressions.Expression{System.Func{`1,``0}},System.Func{``0,System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}}},System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}},System.Func{`1,System.Boolean},System.ValueTuple{System.String,System.Object}[])')
  - [GetEnumerator()](#M-MutatorFX-FilterMutator-ClauseCollection`2-GetEnumerator 'MutatorFX.FilterMutator.ClauseCollection`2.GetEnumerator')
- [ClauseFilterer\`2](#T-MutatorFX-FilterMutator-ClauseFilterer`2 'MutatorFX.FilterMutator.ClauseFilterer`2')
  - [CreateClauses()](#M-MutatorFX-FilterMutator-ClauseFilterer`2-CreateClauses 'MutatorFX.FilterMutator.ClauseFilterer`2.CreateClauses')
  - [Filter(source,filter)](#M-MutatorFX-FilterMutator-ClauseFilterer`2-Filter-System-Linq-IQueryable{`0},`1- 'MutatorFX.FilterMutator.ClauseFilterer`2.Filter(System.Linq.IQueryable{`0},`1)')
  - [GetClauses()](#M-MutatorFX-FilterMutator-ClauseFilterer`2-GetClauses 'MutatorFX.FilterMutator.ClauseFilterer`2.GetClauses')
- [ClosureSourceAccessor\`1](#T-MutatorFX-FilterMutator-ClosureSourceAccessor`1 'MutatorFX.FilterMutator.ClosureSourceAccessor`1')
  - [#ctor(sourceAccessor)](#M-MutatorFX-FilterMutator-ClosureSourceAccessor`1-#ctor-System-Func{System-Linq-IQueryable{`0}}- 'MutatorFX.FilterMutator.ClosureSourceAccessor`1.#ctor(System.Func{System.Linq.IQueryable{`0}})')
  - [Source](#P-MutatorFX-FilterMutator-ClosureSourceAccessor`1-Source 'MutatorFX.FilterMutator.ClosureSourceAccessor`1.Source')
- [CompositeQueryExecutor\`4](#T-MutatorFX-FilterMutator-CompositeQueryExecutor`4 'MutatorFX.FilterMutator.CompositeQueryExecutor`4')
  - [#ctor(sourceAccessor,filterer,transformer,sorter,pager)](#M-MutatorFX-FilterMutator-CompositeQueryExecutor`4-#ctor-MutatorFX-FilterMutator-ISourceAccessor{`0},MutatorFX-FilterMutator-IFilterer{`0,`2},MutatorFX-FilterMutator-ITransformer{`0,`1},MutatorFX-FilterMutator-ISorter{`0,`3},MutatorFX-FilterMutator-IPager{`1}- 'MutatorFX.FilterMutator.CompositeQueryExecutor`4.#ctor(MutatorFX.FilterMutator.ISourceAccessor{`0},MutatorFX.FilterMutator.IFilterer{`0,`2},MutatorFX.FilterMutator.ITransformer{`0,`1},MutatorFX.FilterMutator.ISorter{`0,`3},MutatorFX.FilterMutator.IPager{`1})')
  - [Filterer](#P-MutatorFX-FilterMutator-CompositeQueryExecutor`4-Filterer 'MutatorFX.FilterMutator.CompositeQueryExecutor`4.Filterer')
  - [Pager](#P-MutatorFX-FilterMutator-CompositeQueryExecutor`4-Pager 'MutatorFX.FilterMutator.CompositeQueryExecutor`4.Pager')
  - [Sorter](#P-MutatorFX-FilterMutator-CompositeQueryExecutor`4-Sorter 'MutatorFX.FilterMutator.CompositeQueryExecutor`4.Sorter')
  - [Source](#P-MutatorFX-FilterMutator-CompositeQueryExecutor`4-Source 'MutatorFX.FilterMutator.CompositeQueryExecutor`4.Source')
  - [SourceAccessor](#P-MutatorFX-FilterMutator-CompositeQueryExecutor`4-SourceAccessor 'MutatorFX.FilterMutator.CompositeQueryExecutor`4.SourceAccessor')
  - [Transformer](#P-MutatorFX-FilterMutator-CompositeQueryExecutor`4-Transformer 'MutatorFX.FilterMutator.CompositeQueryExecutor`4.Transformer')
  - [Filter(source,filter)](#M-MutatorFX-FilterMutator-CompositeQueryExecutor`4-Filter-System-Linq-IQueryable{`0},`2- 'MutatorFX.FilterMutator.CompositeQueryExecutor`4.Filter(System.Linq.IQueryable{`0},`2)')
  - [Page(results,page,pageSize)](#M-MutatorFX-FilterMutator-CompositeQueryExecutor`4-Page-System-Linq-IQueryable{`1},System-Int32,System-Int32- 'MutatorFX.FilterMutator.CompositeQueryExecutor`4.Page(System.Linq.IQueryable{`1},System.Int32,System.Int32)')
  - [Sort(filtered,sorting,sortDescending)](#M-MutatorFX-FilterMutator-CompositeQueryExecutor`4-Sort-System-Linq-IQueryable{`0},`3,System-Boolean- 'MutatorFX.FilterMutator.CompositeQueryExecutor`4.Sort(System.Linq.IQueryable{`0},`3,System.Boolean)')
  - [Transform(source)](#M-MutatorFX-FilterMutator-CompositeQueryExecutor`4-Transform-System-Linq-IQueryable{`0}- 'MutatorFX.FilterMutator.CompositeQueryExecutor`4.Transform(System.Linq.IQueryable{`0})')
- [ExpressionSorter\`2](#T-MutatorFX-FilterMutator-ExpressionSorter`2 'MutatorFX.FilterMutator.ExpressionSorter`2')
  - [#ctor(keySelector)](#M-MutatorFX-FilterMutator-ExpressionSorter`2-#ctor-System-Func{`1,System-Linq-Expressions-Expression{System-Func{`0,System-Object}}}- 'MutatorFX.FilterMutator.ExpressionSorter`2.#ctor(System.Func{`1,System.Linq.Expressions.Expression{System.Func{`0,System.Object}}})')
  - [KeySelector(sort)](#M-MutatorFX-FilterMutator-ExpressionSorter`2-KeySelector-`1- 'MutatorFX.FilterMutator.ExpressionSorter`2.KeySelector(`1)')
- [ExpressionTransformer\`2](#T-MutatorFX-FilterMutator-ExpressionTransformer`2 'MutatorFX.FilterMutator.ExpressionTransformer`2')
  - [#ctor(transformExpression)](#M-MutatorFX-FilterMutator-ExpressionTransformer`2-#ctor-System-Linq-Expressions-Expression{System-Func{`0,`1}}- 'MutatorFX.FilterMutator.ExpressionTransformer`2.#ctor(System.Linq.Expressions.Expression{System.Func{`0,`1}})')
  - [Transform(source)](#M-MutatorFX-FilterMutator-ExpressionTransformer`2-Transform-System-Linq-IQueryable{`0}- 'MutatorFX.FilterMutator.ExpressionTransformer`2.Transform(System.Linq.IQueryable{`0})')
- [FilterClause\`3](#T-MutatorFX-FilterMutator-FilterClause`3 'MutatorFX.FilterMutator.FilterClause`3')
  - [#ctor(filterClauseSelector,filterPredicate,onDisabledFilterPredicate,isClauseEnabled,options)](#M-MutatorFX-FilterMutator-FilterClause`3-#ctor-System-Linq-Expressions-Expression{System-Func{`1,`2}},System-Func{`2,System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}}},System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{`1,System-Boolean},System-Collections-Generic-Dictionary{System-String,System-Object}- 'MutatorFX.FilterMutator.FilterClause`3.#ctor(System.Linq.Expressions.Expression{System.Func{`1,`2}},System.Func{`2,System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}}},System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}},System.Func{`1,System.Boolean},System.Collections.Generic.Dictionary{System.String,System.Object})')
  - [ClauseExpression](#P-MutatorFX-FilterMutator-FilterClause`3-ClauseExpression 'MutatorFX.FilterMutator.FilterClause`3.ClauseExpression')
  - [Options](#P-MutatorFX-FilterMutator-FilterClause`3-Options 'MutatorFX.FilterMutator.FilterClause`3.Options')
  - [Execute(source,filter)](#M-MutatorFX-FilterMutator-FilterClause`3-Execute-System-Linq-IQueryable{`0},`1- 'MutatorFX.FilterMutator.FilterClause`3.Execute(System.Linq.IQueryable{`0},`1)')
  - [GetClause(filter)](#M-MutatorFX-FilterMutator-FilterClause`3-GetClause-`1- 'MutatorFX.FilterMutator.FilterClause`3.GetClause(`1)')
  - [GetFilterPredicate(filter)](#M-MutatorFX-FilterMutator-FilterClause`3-GetFilterPredicate-`1- 'MutatorFX.FilterMutator.FilterClause`3.GetFilterPredicate(`1)')
  - [GetOnDisabledFilterPredicate()](#M-MutatorFX-FilterMutator-FilterClause`3-GetOnDisabledFilterPredicate 'MutatorFX.FilterMutator.FilterClause`3.GetOnDisabledFilterPredicate')
  - [IsClauseEnabled(filter)](#M-MutatorFX-FilterMutator-FilterClause`3-IsClauseEnabled-`1- 'MutatorFX.FilterMutator.FilterClause`3.IsClauseEnabled(`1)')
  - [MutatorFX#FilterMutator#IFilterClause{TSource,TFilter}#GetClause(filter)](#M-MutatorFX-FilterMutator-FilterClause`3-MutatorFX#FilterMutator#IFilterClause{TSource,TFilter}#GetClause-`1- 'MutatorFX.FilterMutator.FilterClause`3.MutatorFX#FilterMutator#IFilterClause{TSource,TFilter}#GetClause(`1)')
- [NoopFilterer\`2](#T-MutatorFX-FilterMutator-NoopFilterer`2 'MutatorFX.FilterMutator.NoopFilterer`2')
  - [Filter(source,filter)](#M-MutatorFX-FilterMutator-NoopFilterer`2-Filter-System-Linq-IQueryable{`0},`1- 'MutatorFX.FilterMutator.NoopFilterer`2.Filter(System.Linq.IQueryable{`0},`1)')
- [PropertyChainNameSorter\`2](#T-MutatorFX-FilterMutator-PropertyChainNameSorter`2 'MutatorFX.FilterMutator.PropertyChainNameSorter`2')
  - [Lookup](#P-MutatorFX-FilterMutator-PropertyChainNameSorter`2-Lookup 'MutatorFX.FilterMutator.PropertyChainNameSorter`2.Lookup')
  - [KeySelector(sort)](#M-MutatorFX-FilterMutator-PropertyChainNameSorter`2-KeySelector-`1- 'MutatorFX.FilterMutator.PropertyChainNameSorter`2.KeySelector(`1)')
- [QueryExecutorBase\`4](#T-MutatorFX-FilterMutator-QueryExecutorBase`4 'MutatorFX.FilterMutator.QueryExecutorBase`4')
  - [Source](#P-MutatorFX-FilterMutator-QueryExecutorBase`4-Source 'MutatorFX.FilterMutator.QueryExecutorBase`4.Source')
  - [ExecuteQuery(filter,page,pageSize,sorting,sortDescending)](#M-MutatorFX-FilterMutator-QueryExecutorBase`4-ExecuteQuery-`2,System-Int32,System-Int32,`3,System-Boolean- 'MutatorFX.FilterMutator.QueryExecutorBase`4.ExecuteQuery(`2,System.Int32,System.Int32,`3,System.Boolean)')
  - [Filter(source,filter)](#M-MutatorFX-FilterMutator-QueryExecutorBase`4-Filter-System-Linq-IQueryable{`0},`2- 'MutatorFX.FilterMutator.QueryExecutorBase`4.Filter(System.Linq.IQueryable{`0},`2)')
  - [Page(results,page,pageSize)](#M-MutatorFX-FilterMutator-QueryExecutorBase`4-Page-System-Linq-IQueryable{`1},System-Int32,System-Int32- 'MutatorFX.FilterMutator.QueryExecutorBase`4.Page(System.Linq.IQueryable{`1},System.Int32,System.Int32)')
  - [Sort(filtered,sort,sortDescending)](#M-MutatorFX-FilterMutator-QueryExecutorBase`4-Sort-System-Linq-IQueryable{`0},`3,System-Boolean- 'MutatorFX.FilterMutator.QueryExecutorBase`4.Sort(System.Linq.IQueryable{`0},`3,System.Boolean)')
  - [Transform(source)](#M-MutatorFX-FilterMutator-QueryExecutorBase`4-Transform-System-Linq-IQueryable{`0}- 'MutatorFX.FilterMutator.QueryExecutorBase`4.Transform(System.Linq.IQueryable{`0})')
- [SimplePager\`1](#T-MutatorFX-FilterMutator-SimplePager`1 'MutatorFX.FilterMutator.SimplePager`1')
  - [Page(results,page,pageSize)](#M-MutatorFX-FilterMutator-SimplePager`1-Page-System-Linq-IQueryable{`0},System-Int32,System-Int32- 'MutatorFX.FilterMutator.SimplePager`1.Page(System.Linq.IQueryable{`0},System.Int32,System.Int32)')

<a name='T-MutatorFX-FilterMutator-AscDescSorterBase`2'></a>
## AscDescSorterBase\`2 `type`

##### Namespace

MutatorFX.FilterMutator

##### Summary

A simple abstract base class for sorting a datasource in ascending or descending order.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The type of the elements in the source dataset. |
| TSort | The type of the enum that reprensents the sorting types. |

<a name='M-MutatorFX-FilterMutator-AscDescSorterBase`2-KeySelector-`1-'></a>
### KeySelector(sort) `method`

##### Summary

Get the expression to select the key for ordering a source dataset.

##### Returns

The Expression used by [OrderBy\`\`2](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Queryable.OrderBy``2 'System.Linq.Queryable.OrderBy``2(System.Linq.IQueryable{``0},System.Linq.Expressions.Expression{System.Func{``0,``1}})')or [OrderByDescending\`\`2](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Queryable.OrderByDescending``2 'System.Linq.Queryable.OrderByDescending``2(System.Linq.IQueryable{``0},System.Linq.Expressions.Expression{System.Func{``0,``1}})')(based on the value of ascending or descending ordering).

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sort | [\`1](#T-`1 '`1') | The value of the sorting enum. |

<a name='M-MutatorFX-FilterMutator-AscDescSorterBase`2-Sort-System-Linq-IQueryable{`0},`1,System-Boolean-'></a>
### Sort(filtered,sort,sortDescending) `method`

##### Summary

Sorts the `filtered`dataset using the `sort`value to get the key via [KeySelector](#M-MutatorFX-FilterMutator-AscDescSorterBase`2-KeySelector-`1- 'MutatorFX.FilterMutator.AscDescSorterBase`2.KeySelector(`1)'), and calls either 
[OrderBy\`\`2](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Queryable.OrderBy``2 'System.Linq.Queryable.OrderBy``2(System.Linq.IQueryable{``0},System.Linq.Expressions.Expression{System.Func{``0,``1}})')or [OrderByDescending\`\`2](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Queryable.OrderByDescending``2 'System.Linq.Queryable.OrderByDescending``2(System.Linq.IQueryable{``0},System.Linq.Expressions.Expression{System.Func{``0,``1}})')
based on the value of `sortDescending`.

##### Returns

The sorted dataset, repesented as a queryable of `TSource`objects.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filtered | [System.Linq.IQueryable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{`0}') | The dataset to sort. |
| sort | [\`1](#T-`1 '`1') | The value of the sorting enum to be passed to the [KeySelector](#M-MutatorFX-FilterMutator-AscDescSorterBase`2-KeySelector-`1- 'MutatorFX.FilterMutator.AscDescSorterBase`2.KeySelector(`1)')method to get the sorting expression. |
| sortDescending | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True indicates the resultset should be in descending order. |

<a name='T-MutatorFX-FilterMutator-ClauseCollection`2'></a>
## ClauseCollection\`2 `type`

##### Namespace

MutatorFX.FilterMutator

##### Summary

A collection of filtering clause objects.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The source type to use when filtering. |
| TFilter | The filter type to apply when filtering. |

<a name='P-MutatorFX-FilterMutator-ClauseCollection`2-Clauses'></a>
### Clauses `property`

##### Summary

The clauses contained in this collection.

<a name='M-MutatorFX-FilterMutator-ClauseCollection`2-AddClause``1-System-Linq-Expressions-Expression{System-Func{`1,``0}},System-Func{``0,System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}}},System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{`1,System-Boolean},System-ValueTuple{System-String,System-Object}[]-'></a>
### AddClause\`\`1(filterClauseSelector,filterPredicate,onDisabledFilterPredicate,isClauseEnabled,options) `method`

##### Summary

Adds an [IFilterClause\`2](#T-MutatorFX-FilterMutator-IFilterClause`2 'MutatorFX.FilterMutator.IFilterClause`2')instance to the current collection. 
This method can be used for applying extensions for custom filtering clause implementations.

##### Returns

The current collection after that clause was added to it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filterClauseSelector | [System.Linq.Expressions.Expression{System.Func{\`1,\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`1,``0}}') | The accessor used to get the clause value from a filter. |
| filterPredicate | [System.Func{\`\`0,System.Linq.Expressions.Expression{System.Func{\`0,System.Boolean}}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}}}') | The predicate factory that's used to generate the filtering expression based on the current clause value. |
| onDisabledFilterPredicate | [System.Linq.Expressions.Expression{System.Func{\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}}') | A predicate that is used when the clause is considered disabled for a given filter. The default returns a constant true value for each item in the collection. |
| isClauseEnabled | [System.Func{\`1,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{`1,System.Boolean}') | A function that determines whether the current clause is enabled for a given filter. |
| options | [System.ValueTuple{System.String,System.Object}[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ValueTuple 'System.ValueTuple{System.String,System.Object}[]') | Additional options that can be passed to the clause. Will be converted to a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String')-[String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String')[Dictionary\`2](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary`2 'System.Collections.Generic.Dictionary`2'), so the keys should be unique amongst the parameters. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TClause | The type of the selected clause from `TFilter`. Should be inferred. |

<a name='M-MutatorFX-FilterMutator-ClauseCollection`2-GetEnumerator'></a>
### GetEnumerator() `method`

##### Summary

Returns the enumerator for the [Clauses](#P-MutatorFX-FilterMutator-ClauseCollection`2-Clauses 'MutatorFX.FilterMutator.ClauseCollection`2.Clauses')in the collection.

##### Parameters

This method has no parameters.

<a name='T-MutatorFX-FilterMutator-ClauseFilterer`2'></a>
## ClauseFilterer\`2 `type`

##### Namespace

MutatorFX.FilterMutator

##### Summary

A simple [IFilterer\`2](#T-MutatorFX-FilterMutator-IFilterer`2 'MutatorFX.FilterMutator.IFilterer`2')implementation base class for creating a clause-based filtering mechanism.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The type of the source dataset items. |
| TFilter | The type of the input filter used for filtering and creating clauses. |

<a name='M-MutatorFX-FilterMutator-ClauseFilterer`2-CreateClauses'></a>
### CreateClauses() `method`

##### Summary

Factory method to create a generic [ClauseCollection\`2](#T-MutatorFX-FilterMutator-ClauseCollection`2 'MutatorFX.FilterMutator.ClauseCollection`2')for the current type.
Can be used in non-static context to infer the generic type arguments for the collection.

##### Returns

An empty collection of clauses, which can be used to build the individual filter clauses.

##### Parameters

This method has no parameters.

<a name='M-MutatorFX-FilterMutator-ClauseFilterer`2-Filter-System-Linq-IQueryable{`0},`1-'></a>
### Filter(source,filter) `method`

##### Summary

Executes all the available clauses over the given `source`with values obtained for the clauses from the `filter`.

##### Returns

The filtered elements from the `source`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{`0}') | The source to filter with the clauses. |
| filter | [\`1](#T-`1 '`1') | The filter to use when filtering `source`with the clauses provided by [GetClauses](#M-MutatorFX-FilterMutator-ClauseFilterer`2-GetClauses 'MutatorFX.FilterMutator.ClauseFilterer`2.GetClauses'). |

<a name='M-MutatorFX-FilterMutator-ClauseFilterer`2-GetClauses'></a>
### GetClauses() `method`

##### Summary

Get the clauses, which will be used to filter the input datasource with a given filter.
You can use the shorthand static method [CreateClauses](#M-MutatorFX-FilterMutator-ClauseFilterer`2-CreateClauses 'MutatorFX.FilterMutator.ClauseFilterer`2.CreateClauses')to create a static collection and refer it from here,
so that instantiations of the clauses don't happen every time. Take caution not to create the collection every time this 
method gets called unless you intend to generate them at runtime, because it can have performance repercussions.

##### Returns

The clauses used for aggregating over the source dataset.

##### Parameters

This method has no parameters.

<a name='T-MutatorFX-FilterMutator-ClosureSourceAccessor`1'></a>
## ClosureSourceAccessor\`1 `type`

##### Namespace

MutatorFX.FilterMutator

##### Summary

A simple source accessor which accepts an accessor function to provide for the [ISourceAccessor\`1](#T-MutatorFX-FilterMutator-ISourceAccessor`1 'MutatorFX.FilterMutator.ISourceAccessor`1')interface.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The type of the elements in the datasource. |

<a name='M-MutatorFX-FilterMutator-ClosureSourceAccessor`1-#ctor-System-Func{System-Linq-IQueryable{`0}}-'></a>
### #ctor(sourceAccessor) `constructor`

##### Summary

Create a new accessor, which will use the provided function to access the queryable source.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sourceAccessor | [System.Func{System.Linq.IQueryable{\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.IQueryable{`0}}') | The function to use to access the queryable source. |

<a name='P-MutatorFX-FilterMutator-ClosureSourceAccessor`1-Source'></a>
### Source `property`

##### Summary

Use the aquired accessor function to access the queryable source.

<a name='T-MutatorFX-FilterMutator-CompositeQueryExecutor`4'></a>
## CompositeQueryExecutor\`4 `type`

##### Namespace

MutatorFX.FilterMutator

##### Summary

A queryexecutor implementation that accepts all its implementation details via its constructor.
Can be used via DI if all parameters can be trivially resolved.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The type of the elements in the source dataset. |
| TResult | The type of the elements in the result dataset. |
| TFilter | The type of the filter that is used when filtering the source dataset. |
| TSort | The enum type that is used when sorting the dataset. |

<a name='M-MutatorFX-FilterMutator-CompositeQueryExecutor`4-#ctor-MutatorFX-FilterMutator-ISourceAccessor{`0},MutatorFX-FilterMutator-IFilterer{`0,`2},MutatorFX-FilterMutator-ITransformer{`0,`1},MutatorFX-FilterMutator-ISorter{`0,`3},MutatorFX-FilterMutator-IPager{`1}-'></a>
### #ctor(sourceAccessor,filterer,transformer,sorter,pager) `constructor`

##### Summary

Create a new instance of the [CompositeQueryExecutor\`4](#T-MutatorFX-FilterMutator-CompositeQueryExecutor`4 'MutatorFX.FilterMutator.CompositeQueryExecutor`4')with all its implementation details injected via constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sourceAccessor | [MutatorFX.FilterMutator.ISourceAccessor{\`0}](#T-MutatorFX-FilterMutator-ISourceAccessor{`0} 'MutatorFX.FilterMutator.ISourceAccessor{`0}') | The source accessor used to acces the `TSource`elements. |
| filterer | [MutatorFX.FilterMutator.IFilterer{\`0,\`2}](#T-MutatorFX-FilterMutator-IFilterer{`0,`2} 'MutatorFX.FilterMutator.IFilterer{`0,`2}') | The filterer implementation used to filter the dataset. |
| transformer | [MutatorFX.FilterMutator.ITransformer{\`0,\`1}](#T-MutatorFX-FilterMutator-ITransformer{`0,`1} 'MutatorFX.FilterMutator.ITransformer{`0,`1}') | The transformation object that can transform the `TSource`types to `TResult`types. |
| sorter | [MutatorFX.FilterMutator.ISorter{\`0,\`3}](#T-MutatorFX-FilterMutator-ISorter{`0,`3} 'MutatorFX.FilterMutator.ISorter{`0,`3}') |  |
| pager | [MutatorFX.FilterMutator.IPager{\`1}](#T-MutatorFX-FilterMutator-IPager{`1} 'MutatorFX.FilterMutator.IPager{`1}') |  |

<a name='P-MutatorFX-FilterMutator-CompositeQueryExecutor`4-Filterer'></a>
### Filterer `property`

##### Summary

The filterer used to filter the source dataset with a given `TFilter`.

<a name='P-MutatorFX-FilterMutator-CompositeQueryExecutor`4-Pager'></a>
### Pager `property`

##### Summary

A pager object that generates paging results for a given `TResult`dataset.

<a name='P-MutatorFX-FilterMutator-CompositeQueryExecutor`4-Sorter'></a>
### Sorter `property`

##### Summary

A sorter object that sorts a given `TSource`object based on a sorting enum parameter.

<a name='P-MutatorFX-FilterMutator-CompositeQueryExecutor`4-Source'></a>
### Source `property`

##### Summary

The default source accessor implementation uses the injected [SourceAccessor](#P-MutatorFX-FilterMutator-CompositeQueryExecutor`4-SourceAccessor 'MutatorFX.FilterMutator.CompositeQueryExecutor`4.SourceAccessor')to access the source dataset.

<a name='P-MutatorFX-FilterMutator-CompositeQueryExecutor`4-SourceAccessor'></a>
### SourceAccessor `property`

##### Summary

The accessor used to access the source dataset.

<a name='P-MutatorFX-FilterMutator-CompositeQueryExecutor`4-Transformer'></a>
### Transformer `property`

##### Summary

An [ITransformer\`2](#T-MutatorFX-FilterMutator-ITransformer`2 'MutatorFX.FilterMutator.ITransformer`2')that can transform a source queryable to a result queryable dataset.

<a name='M-MutatorFX-FilterMutator-CompositeQueryExecutor`4-Filter-System-Linq-IQueryable{`0},`2-'></a>
### Filter(source,filter) `method`

##### Summary

The default filtering implementation uses the injected [Filterer](#P-MutatorFX-FilterMutator-CompositeQueryExecutor`4-Filterer 'MutatorFX.FilterMutator.CompositeQueryExecutor`4.Filterer')object to filter the given datasource with the provided filter.

##### Returns

The filtered dataset.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{`0}') | The datasource to apply filtering to. |
| filter | [\`2](#T-`2 '`2') | The filter to apply to the datasource. |

<a name='M-MutatorFX-FilterMutator-CompositeQueryExecutor`4-Page-System-Linq-IQueryable{`1},System-Int32,System-Int32-'></a>
### Page(results,page,pageSize) `method`

##### Summary

The default implementation uses the injected [Pager](#P-MutatorFX-FilterMutator-CompositeQueryExecutor`4-Pager 'MutatorFX.FilterMutator.CompositeQueryExecutor`4.Pager')to apply paging to the result dataset.

##### Returns

The paged entries.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| results | [System.Linq.IQueryable{\`1}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{`1}') | The results to apply paging to. |
| page | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The page (1-based) requested. |
| pageSize | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The page size requested. |

<a name='M-MutatorFX-FilterMutator-CompositeQueryExecutor`4-Sort-System-Linq-IQueryable{`0},`3,System-Boolean-'></a>
### Sort(filtered,sorting,sortDescending) `method`

##### Summary

The default sorting implementation uses the injected [Sorter](#P-MutatorFX-FilterMutator-CompositeQueryExecutor`4-Sorter 'MutatorFX.FilterMutator.CompositeQueryExecutor`4.Sorter')object to sort the given source dataset.

##### Returns

The sorted dataset.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filtered | [System.Linq.IQueryable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{`0}') | The filtered, unsorted dataset to apply sorting to. |
| sorting | [\`3](#T-`3 '`3') | The sorting value to determine the kind of sorting to use. |
| sortDescending | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | The order of sorting. |

<a name='M-MutatorFX-FilterMutator-CompositeQueryExecutor`4-Transform-System-Linq-IQueryable{`0}-'></a>
### Transform(source) `method`

##### Summary

The default transformation implementation uses the injected [Transformer](#P-MutatorFX-FilterMutator-CompositeQueryExecutor`4-Transformer 'MutatorFX.FilterMutator.CompositeQueryExecutor`4.Transformer')object to transform the source dataset to the result dataset.

##### Returns

The transformed objects.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{`0}') | The source objects to transform to `TResult`. |

<a name='T-MutatorFX-FilterMutator-ExpressionSorter`2'></a>
## ExpressionSorter\`2 `type`

##### Namespace

MutatorFX.FilterMutator

##### Summary

A simple [AscDescSorterBase\`2](#T-MutatorFX-FilterMutator-AscDescSorterBase`2 'MutatorFX.FilterMutator.AscDescSorterBase`2')implementation, which accepts the implementation details in constructor.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The source types to sort. |
| TSort | The sort enum type to use for sorting. |

<a name='M-MutatorFX-FilterMutator-ExpressionSorter`2-#ctor-System-Func{`1,System-Linq-Expressions-Expression{System-Func{`0,System-Object}}}-'></a>
### #ctor(keySelector) `constructor`

##### Summary

Create a simple sorter which accepts the implementation details to use for sorting.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| keySelector | [System.Func{\`1,System.Linq.Expressions.Expression{System.Func{\`0,System.Object}}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{`1,System.Linq.Expressions.Expression{System.Func{`0,System.Object}}}') | The factory method used to get the keySelector [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression')for a given `TSort`value. |

<a name='M-MutatorFX-FilterMutator-ExpressionSorter`2-KeySelector-`1-'></a>
### KeySelector(sort) `method`

##### Summary

Use the aquired factory function to get the selector for the sorting function.

##### Returns

The expression used to select the key from a `TSource`object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sort | [\`1](#T-`1 '`1') | The value of the sorting enum used to aquire the keySelector for. |

<a name='T-MutatorFX-FilterMutator-ExpressionTransformer`2'></a>
## ExpressionTransformer\`2 `type`

##### Namespace

MutatorFX.FilterMutator

##### Summary

A simple [ITransformer\`2](#T-MutatorFX-FilterMutator-ITransformer`2 'MutatorFX.FilterMutator.ITransformer`2')implementation, which accepts the implementation details in constructor.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The source type to transform. |
| TResult | The result type to transform `TSource`to. |

<a name='M-MutatorFX-FilterMutator-ExpressionTransformer`2-#ctor-System-Linq-Expressions-Expression{System-Func{`0,`1}}-'></a>
### #ctor(transformExpression) `constructor`

##### Summary

Create a simple transformer, which will use the provided expression to transform the source to the result dataset.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| transformExpression | [System.Linq.Expressions.Expression{System.Func{\`0,\`1}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`0,`1}}') | The expression used to transform from `TSource`to `TResult`. |

<a name='M-MutatorFX-FilterMutator-ExpressionTransformer`2-Transform-System-Linq-IQueryable{`0}-'></a>
### Transform(source) `method`

##### Summary

Use the aquired expression to transform the `source`dataset to the result dataset.

##### Returns

The transformed results.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{`0}') | The source to transform. |

<a name='T-MutatorFX-FilterMutator-FilterClause`3'></a>
## FilterClause\`3 `type`

##### Namespace

MutatorFX.FilterMutator

##### Summary

Represents the default implementation of a clause used for filtering. Provides a way to select 
a clause from a filter object, execute the clause on a given dataset, or fallback to a default
filtering mechanism when the clause is considered disabled.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The type of the source objects in the dataset to be filtered. |
| TFilter | The filter type to select the clause from to apply to the dataset. |
| TClause | The type of the selected clause. |

<a name='M-MutatorFX-FilterMutator-FilterClause`3-#ctor-System-Linq-Expressions-Expression{System-Func{`1,`2}},System-Func{`2,System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}}},System-Linq-Expressions-Expression{System-Func{`0,System-Boolean}},System-Func{`1,System-Boolean},System-Collections-Generic-Dictionary{System-String,System-Object}-'></a>
### #ctor(filterClauseSelector,filterPredicate,onDisabledFilterPredicate,isClauseEnabled,options) `constructor`

##### Summary

Create a new clause used for filtering.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filterClauseSelector | [System.Linq.Expressions.Expression{System.Func{\`1,\`2}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`1,`2}}') | A selector that can be used to aquire the clause value from a given filter. As 
it is an Expression, it can be used to rationalize about a collection of clauses. |
| filterPredicate | [System.Func{\`2,System.Linq.Expressions.Expression{System.Func{\`0,System.Boolean}}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{`2,System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}}}') | The predicate factory to use when building the filtering expressions. Can be a lambda,
that gets the selected clause value from the filter as parameter, that returns another lamdbda
that uses closure on the outer clause parameter to apply dynamically parametered filtering.



Example:

```csharp
(clause: Clause) =&gt; (source: TSource) =&gt; source.Name.Contains(clause);  
``` |
| onDisabledFilterPredicate | [System.Linq.Expressions.Expression{System.Func{\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}}') | A predicate that gets used instead of 
`filterPredicate`when the clause is considered disabled. |
| isClauseEnabled | [System.Func{\`1,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{`1,System.Boolean}') | A predicate that indicates whether the clause is to be
considered enabled. |
| options | [System.Collections.Generic.Dictionary{System.String,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{System.String,System.Object}') | Additional untyped options. Can be used for extensibility to add 
state or configuration to the clause via extensions. |

<a name='P-MutatorFX-FilterMutator-FilterClause`3-ClauseExpression'></a>
### ClauseExpression `property`

##### Summary

The expression that represents the clause selector. Can be used to rationalize
about this clause in regards to other clauses (i.e. to check whether all filter
properties are matched in a collection of clauses).

<a name='P-MutatorFX-FilterMutator-FilterClause`3-Options'></a>
### Options `property`

##### Summary

The options passed to this clause instance used to apply additional logic 
based on state via extensions.

<a name='M-MutatorFX-FilterMutator-FilterClause`3-Execute-System-Linq-IQueryable{`0},`1-'></a>
### Execute(source,filter) `method`

##### Summary

Executes a filtering by applying one of provided predicates to filter the given datasource.

##### Returns

The dataset filtered by the predicate described by this clause.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{`0}') | The source to filter by this clause's value. |
| filter | [\`1](#T-`1 '`1') | The filter to get the clause value from. |

<a name='M-MutatorFX-FilterMutator-FilterClause`3-GetClause-`1-'></a>
### GetClause(filter) `method`

##### Summary

Gets the clause object's value by applying the clause selector to the filter.

##### Returns

The clause value in the given object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filter | [\`1](#T-`1 '`1') | The filter object to apply the selector to. |

<a name='M-MutatorFX-FilterMutator-FilterClause`3-GetFilterPredicate-`1-'></a>
### GetFilterPredicate(filter) `method`

##### Summary

Get the predicate expression for a given source item by a given filter, which
indicates whether the given source item should be in the filtered resultset or not.

##### Returns

The expression that represents a predicate delegate, that can be used to
filter the source dataset by the clause value. Returns null if the 
[FilterPredicate](#P-MutatorFX-FilterMutator-FilterClause`3-FilterPredicate 'MutatorFX.FilterMutator.FilterClause`3.FilterPredicate')is null.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filter | [\`1](#T-`1 '`1') | The filter object to get the predicate clause from. |

<a name='M-MutatorFX-FilterMutator-FilterClause`3-GetOnDisabledFilterPredicate'></a>
### GetOnDisabledFilterPredicate() `method`

##### Summary

Gets the predicate that should be applied when the filter is considered disabled.
If no custom predicate was supplied, the default is an always truthy predicate.

##### Returns

The predicate to use for filtering, or a truthy predicate if none was supplied.

##### Parameters

This method has no parameters.

<a name='M-MutatorFX-FilterMutator-FilterClause`3-IsClauseEnabled-`1-'></a>
### IsClauseEnabled(filter) `method`

##### Summary

Determine whether the clause is enabled for the given filter.
Uses the `TClause`type's default [EqualityComparer\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.EqualityComparer`1 'System.Collections.Generic.EqualityComparer`1')if none was supplied.

##### Returns

True if the filter is considered enabled.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filter | [\`1](#T-`1 '`1') | The filter to use when checking the clause's disabled state. |

<a name='M-MutatorFX-FilterMutator-FilterClause`3-MutatorFX#FilterMutator#IFilterClause{TSource,TFilter}#GetClause-`1-'></a>
### MutatorFX#FilterMutator#IFilterClause{TSource,TFilter}#GetClause(filter) `method`

##### Summary

Gets the clause object's value by applying the clause selector to the filter.

##### Returns

The clause value in the given object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filter | [\`1](#T-`1 '`1') | The filter object to apply the selector to. |

<a name='T-MutatorFX-FilterMutator-NoopFilterer`2'></a>
## NoopFilterer\`2 `type`

##### Namespace

MutatorFX.FilterMutator

##### Summary

A simple filterer implementation that returns the input datasource (does not filter). Can be used for mocking and testing or composition.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The source type to apply no filtering to. |
| TFilter | The filter type, not used. |

<a name='M-MutatorFX-FilterMutator-NoopFilterer`2-Filter-System-Linq-IQueryable{`0},`1-'></a>
### Filter(source,filter) `method`

##### Summary

Returns the input `source`object.

##### Returns

The `source`object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{`0}') | This object is returned. |
| filter | [\`1](#T-`1 '`1') | This object is ignored. |

<a name='T-MutatorFX-FilterMutator-PropertyChainNameSorter`2'></a>
## PropertyChainNameSorter\`2 `type`

##### Namespace

MutatorFX.FilterMutator

##### Summary

A sorter object that can be used to apply sorting to a given source dataset.
This implementation instantiates a static cache for any given `TSort`parameter,
which can throw if no matching property chains are found for any name in the given `TSort`enum.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The type of the elements in the source dataset. |
| TSort | The enum type. This enum should only contain names that can be resolved to property chains 
without the separating dot, otherwise the static cache will throw. |

<a name='P-MutatorFX-FilterMutator-PropertyChainNameSorter`2-Lookup'></a>
### Lookup `property`

##### Summary

The global cache lookup for any given `TSort`type.

<a name='M-MutatorFX-FilterMutator-PropertyChainNameSorter`2-KeySelector-`1-'></a>
### KeySelector(sort) `method`

##### Summary

Uses the static cache [Lookup](#P-MutatorFX-FilterMutator-PropertyChainNameSorter`2-Lookup 'MutatorFX.FilterMutator.PropertyChainNameSorter`2.Lookup')to get the sorter property based on the `TSort`enum value provided.
Throws if the given key was not found in the lookup.

##### Returns

The expression used to aquire the key to apply sorting for.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sort | [\`1](#T-`1 '`1') | The value to look for in the lookup and use. |

<a name='T-MutatorFX-FilterMutator-QueryExecutorBase`4'></a>
## QueryExecutorBase\`4 `type`

##### Namespace

MutatorFX.FilterMutator

##### Summary

A base implementation that provides a paging mechanism and composes the query to a resultset.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The type of the elements in the source dataset. |
| TResult | The type of the elements in the result dataset. |
| TFilter | The type of the filter used in filtering the dataset. |
| TSort | The enum type that is used to sort the dataset before paging is applied. |

<a name='P-MutatorFX-FilterMutator-QueryExecutorBase`4-Source'></a>
### Source `property`

##### Summary

The accessor for the queryable datasource.

<a name='M-MutatorFX-FilterMutator-QueryExecutorBase`4-ExecuteQuery-`2,System-Int32,System-Int32,`3,System-Boolean-'></a>
### ExecuteQuery(filter,page,pageSize,sorting,sortDescending) `method`

##### Summary

Executes the query with the given filtering, paging and sorting parameters on the source dataset.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filter | [\`2](#T-`2 '`2') | The filter object to use when filtering the queryable source dataset. |
| page | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The page requested for the query. |
| pageSize | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The page size requested for the query. |
| sorting | [\`3](#T-`3 '`3') | The sorting used when querying the dataset. |
| sortDescending | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Whether to use descending ordering of the results in the dataset. |

<a name='M-MutatorFX-FilterMutator-QueryExecutorBase`4-Filter-System-Linq-IQueryable{`0},`2-'></a>
### Filter(source,filter) `method`

##### Summary

Filters the given queryable datasource with the given filter.

##### Returns

The filtered datasource queryable.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{`0}') | The source to filter. |
| filter | [\`2](#T-`2 '`2') | The filter object to use when filtering the source. |

<a name='M-MutatorFX-FilterMutator-QueryExecutorBase`4-Page-System-Linq-IQueryable{`1},System-Int32,System-Int32-'></a>
### Page(results,page,pageSize) `method`

##### Summary

Apply paging to a resultset queryable.

##### Returns

The elements in the queryable corresponding to the requested page.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| results | [System.Linq.IQueryable{\`1}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{`1}') | The results to apply paging to. |
| page | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The page requested. |
| pageSize | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The page size requested. |

<a name='M-MutatorFX-FilterMutator-QueryExecutorBase`4-Sort-System-Linq-IQueryable{`0},`3,System-Boolean-'></a>
### Sort(filtered,sort,sortDescending) `method`

##### Summary

Sorts the queryable datasource with the given sorting options.

##### Returns

The sorted queryable dataset.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filtered | [System.Linq.IQueryable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{`0}') | The dataset to sort. |
| sort | [\`3](#T-`3 '`3') | The sorting enum used to parameterize the sorting. |
| sortDescending | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Whether to use descending ordering for sorting. |

<a name='M-MutatorFX-FilterMutator-QueryExecutorBase`4-Transform-System-Linq-IQueryable{`0}-'></a>
### Transform(source) `method`

##### Summary

Transforms the given `TSource`datasource to a set of `TResult`results.

##### Returns

The transformed queryable datasource.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{`0}') | The source to transform. |

<a name='T-MutatorFX-FilterMutator-SimplePager`1'></a>
## SimplePager\`1 `type`

##### Namespace

MutatorFX.FilterMutator

##### Summary

A simple paging implementation that uses [Skip\`\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Queryable.Skip``1 'System.Linq.Queryable.Skip``1(System.Linq.IQueryable{``0},System.Int32)')and [Take\`\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Queryable.Take``1 'System.Linq.Queryable.Take``1(System.Linq.IQueryable{``0},System.Int32)').

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TResult | The type of the elements in the dataset to page. |

<a name='M-MutatorFX-FilterMutator-SimplePager`1-Page-System-Linq-IQueryable{`0},System-Int32,System-Int32-'></a>
### Page(results,page,pageSize) `method`

##### Summary

Get the paged results based on the input parameters.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| results | [System.Linq.IQueryable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{`0}') | The results to page. |
| page | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The value of the page. Should be positive. |
| pageSize | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The page size to apply when paging. Should be positive. |
